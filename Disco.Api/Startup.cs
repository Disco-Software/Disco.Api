using System;
using System.Reflection;
using Azure.Core.Extensions;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Disco.Api.AppSetup;
using Disco.Api.Middlewares;
using Disco.ApiServices.Hubs;
using Disco.Business;
using Disco.Business.Configurations;
using Disco.Business.Interfaces;
using Disco.Business.Services;
using Disco.Domain;
using Disco.Domain.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            // services.ConfigureSwagger();

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
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/Error");
            app.UseHsts();

            ILogger logger = loggerFactory.CreateLogger("ClientErrorLogger");
            
            app.UseRouting();
            app.ApplicationServices.CreateScope();
            app.UseAuthorization();
            app.UseAuthentication();

            var service = serviceScopeFactory.CreateScope().ServiceProvider;
            service.GetRequiredService(typeof(UserManager<User>));

            app.UseWebSockets();

            app.MapWebSocketRequest("/ws/like");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
