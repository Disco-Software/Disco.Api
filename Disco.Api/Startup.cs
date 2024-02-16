using Azure.Core.Extensions;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Disco.Api.AppSetup;
using Disco.ApiServices.Features.Comment;
using Disco.ApiServices.Features.Message;
using Disco.ApiServices.Features.TicketMessage;
using Disco.ApiServices.Filters;
using Disco.Business.Interfaces.Options;
using Disco.Business.Interfaces.Options.EmailConfirmation;
using Disco.Business.Interfaces.Options.PasswordRecovery;
using Disco.Business.Services.Extentions;
using Disco.Domain.Data.Extentions;
using Disco.Domain.Repositories.Extentions;
using Disco.Integration.Clients.Extentions;
using Disco.Integration.Interfaces.Options;
using Disco.Intergration.EventPublisher.Extentions;
using FluentValidation.AspNetCore;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Stripe;
using System;
using System.Reflection;

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
            var connectionStrings = Configuration.GetSection(nameof(ConnectionStrings))
                .Get<ConnectionStrings>();

            services.AddApiDbContext(connectionStrings.DevelopmentConnection);
            services.AddUserIdentity();
            services.AddAuthorization();

            //services.ConfigureCorsPolicy();

            services.AddAzureServices(Configuration);
            services.AddSignalR(options =>
            {
                options.MaximumReceiveMessageSize = 100000000;
                options.EnableDetailedErrors = true;
                options.HandshakeTimeout = TimeSpan.FromMinutes(2);
                options.KeepAliveInterval = TimeSpan.FromMinutes(1);
            });
            services.AddOptions<AuthenticationOptions>();
            services.Configure<EmailOptions>(Configuration.GetSection("EmailSettings"));
            services.Configure<GoogleOptions>(Configuration.GetSection("Google"));
            services.AddUserAuthentication(Configuration);
            services.AddMemoryCache();
            services.AddSession();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(opt =>
            //    {
            //        opt.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            // token validation code
            //        };
            //        opt.Events = new JwtBearerEvents
            //        {
            //            OnMessageReceived = context =>
            //            {
            //                var accessToken = context.Request.Query["access_token"];
            //                var path = context.HttpContext.Request.Path;
            //                if (!string.IsNullOrEmpty(accessToken)
            //                    && path.StartsWithSegments("/kitchen"))
            //                {
            //                    context.Token = accessToken;
            //                }
            //                return Task.CompletedTask;
            //            }
            //        };
            //    });
            //services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddLogging();

            //services.ConfigureRepositories();
            //services.ConfigureServices();
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(CorsPolicyExtentions))));
            services.AddRepositories();
            services.AddService();
            services.AddIntegrations();
            services.AddServiceBus(Configuration);

            services.AddTransient<ISmtpClient, SmtpClient>();

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
            services.AddOptions<StripeOptions>()
                .Configure(Configuration.GetSection("Stripe").Bind)
                .ValidateDataAnnotations();

            services.Configure<EmailConfirmationCodeConfigurationOptions>(Configuration.GetSection("EmailConfirmationSettings").Bind);

            services.Configure<PasswordRecoveryOptions>(Configuration.GetSection("PasswordRecovery"));

            services.AddAutoMapper();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilter));
            });

            services.AddControllers()
            .AddControllersAsServices()
            .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()))
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
            StripeConfiguration.SetApiKey(Configuration.GetSection("StripeOptions")["PrivateKey"]);

            if (env.IsDevelopment())
            {
                //app.UseSwagger(swagger =>
                //{
                //    swagger.SerializeAsV2 = true;
                //});
                //app.UseSwaggerUI(swagger => {
                //    swagger.SwaggerEndpoint("v1/swagger.json", "Disco.Api");
                //});

                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/Error");
            app.UseHsts();
            //app.UseHttpsRedirection();

            ILogger logger = loggerFactory.CreateLogger("ClientErrorLogger");

            app.UseCors(x =>
            {
                x.AllowAnyMethod()
                 .AllowAnyHeader()
                 .SetIsOriginAllowed(origin => true)
                 .AllowCredentials();
            });

            app.UseRouting();
            app.ApplicationServices.CreateScope();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWebSockets();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<CommentComunicationHub>("/hub/comments");
                endpoints.MapHub<MessageComunicationHub>("/hub/message");
                endpoints.MapHub<TicketMessageCommunicationHub>("/hub/ticket");
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
