using System;
using System.Reflection;
using Azure.Core.Extensions;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Disco.Api.AppSetup;
using Disco.Business;
using Disco.Business.Options;
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
using Disco.Business.Constants;
using Disco.ApiServices.Hubs;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

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
            var connectionStrings = Configuration.GetSection("ConnectionStrings")
                .Get<ConnectionStrings>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { });
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.ConfigureDbContext(connectionStrings.ProdactionConnection);
            services.ConfigureIdentity();
            services.AddAuthorization();

            services.ConfigureCorsPolicy();

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
            services.AddOptions<GoogleOptions>()
                .Configure(Configuration.GetSection("Google").Bind)
                .ValidateDataAnnotations();
            services.AddOptions<AudDOptions>()
                .Configure(Configuration.GetSection("AudDOptions").Bind)
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
                app.UseSwagger(swagger =>
                {
                    swagger.SerializeAsV2 = true;
                });
                app.UseSwaggerUI(swagger => {
                    swagger.SwaggerEndpoint("v1/swagger.json", "Disco.Api");
                });

                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/Error");
            app.UseHsts();
            app.UseHttpsRedirection();

            ILogger logger = loggerFactory.CreateLogger("ClientErrorLogger");

            app.UseCors();

            app.UseRouting();
            app.ApplicationServices.CreateScope();
            app.UseAuthentication();
            app.UseAuthorization();

            var service = serviceScopeFactory.CreateScope().ServiceProvider;
            service.GetRequiredService(typeof(UserManager<User>));

            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<CommentHub>("/hub/comments");
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
