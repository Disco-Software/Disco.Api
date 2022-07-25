using Disco.Business.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using FluentValidation.AspNetCore;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;
using Azure.Storage.Queues;
using Azure.Core.Extensions;
using Disco.ApiServices.Hubs;
using Disco.Business;
using Disco.Domain;
using Disco.Api.AppSetup;

namespace Disco.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSwagger();

            services.ConfigureDbContext(Configuration);
            services.ConfigureIdentity();
            services.ConfigureAzureServices(Configuration);
            services.AddSignalR(options => {
                options.EnableDetailedErrors = true;
            });
            services.AddOptions<AuthenticationOptions>();
            services.Configure<EmailOptions>(Configuration.GetSection("EmailSettings"));
            services.Configure<GoogleOptions>(Configuration.GetSection("Google"));
            services.ConfigureAuthentication(Configuration);

            services.AddHttpContextAccessor();
            services.AddHttpClient();

            services.AddLogging();

            services.ConfigureRepositories();
            services.ConfigureServices();

            services.AddOptions<PushNotificationOptions>()
                .Configure(Configuration.GetSection("NotificationHub").Bind)
                .ValidateDataAnnotations();
            services.AddOptions<AuthenticationOptions>()
                .Configure(Configuration.GetSection("Auth:Jwt").Bind)
                .ValidateDataAnnotations();

            services.ConfigureAutoMapper();

            services.AddControllers()
                .AddControllersAsServices()
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()))
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/Error");
            app.UseHsts();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
           
            app.UseSwaggerUI(u =>
            {
                u.SwaggerEndpoint("1.0/swagger.json", "Disco.Api");
            });


            ILogger logger = loggerFactory.CreateLogger("ClientErrorLogger");
            
            app.UseRouting();
            app.ApplicationServices.CreateScope();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<LikeHub>("/hub/like");
            });
        }
    }
    internal static class StartupExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }
    }
}
