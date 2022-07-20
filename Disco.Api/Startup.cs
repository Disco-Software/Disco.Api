using AutoMapper;
using Disco.BLL.Configurations;
using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Mapper;
using Disco.BLL.Services;
using Disco.DAL.EF;
using Disco.DAL.Models;
using Disco.DAL.Models.Base;
using Disco.DAL.Interfaces;
using Disco.DAL.Repositories;
using Disco.DAL.Repositories.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;
using Disco.Api.Hubs;
using Microsoft.AspNetCore.SignalR;
using Azure.Storage.Queues;
using Azure.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Disco.BLL.Validatars;
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
            services.AddSignalR();
            services.AddOptions<AuthenticationOptions>();
            services.Configure<EmailOptions>(Configuration.GetSection("EmailSettings"));
            services.Configure<BLL.Configurations.GoogleOptions>(Configuration.GetSection("Google"));
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

            //app.UseCors(s =>
            //{
            //    s.SetIsOriginAllowed(o => true)
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<LikeHub>("/like");
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
