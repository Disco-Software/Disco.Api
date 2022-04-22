using AutoMapper;
using Disco.BLL.Configurations;
using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Mapper;
using Disco.BLL.Services;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Entities.Base;
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("1.0", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "developer.disco@gmail.com",
                        Name = "Станислав",
                        Url = new Uri("https://www.facebook.com/stas.korchevskyy/")
                    },
                    Title = "Disco.Api",
                    Description = "This Api is for front-end and mobile developers who are developing Disco.",
                    Version = "1.0",
                });
            });
            services.AddSwaggerGen();
            services.AddDbContext<ApiDbContext>(o => 
                o.UseSqlServer(Configuration.GetConnectionString("DevelopmentConnection"), 
                b => b.MigrationsAssembly("../Disco.DAL")));
            

            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            }).AddRoles<Role>()
            .AddEntityFrameworkStores<ApiDbContext>();
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApiDbContext>()
                .AddDefaultTokenProviders();
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration.GetConnectionString("BlobStorage"));
            });

            services.AddSignalR();
            services.AddOptions<AuthenticationOptions>();
            services.Configure<EmailOptions>(Configuration.GetSection("EmailSettings"));
            services.Configure<BLL.Configurations.GoogleOptions>(Configuration.GetSection("Google"));
            services.ConfigureApplicationCookie(s =>
            {
                s.Cookie.HttpOnly = true;
                s.ExpireTimeSpan = TimeSpan.FromMinutes(3000);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
           .AddCookie()
           .AddGoogleOpenIdConnect(options =>
            {
               options.ClientId = Configuration["Google:ClientId"];
               options.ClientSecret = Configuration["Google:SecretKey"];
            }).AddJwtBearer(AuthScheme.UserToken, options =>
            {
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
               {
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidateIssuerSigningKey = true,
                 ValidateLifetime = true,
                 ValidIssuer = Configuration["Auth:Jwt:Issuer"],
                 ValidAudience = Configuration["Auth:Jwt:Audience"],
                 IssuerSigningKey = new SymmetricSecurityKey(
                 Convert.FromBase64String(Configuration["Auth:Jwt:SigningKey"]))
               };
            }).AddFacebook(facebookOptions =>
            {
               facebookOptions.AppId = Configuration["Facebook:AppId"];
               facebookOptions.AppSecret = Configuration["Facebook:SecretKey"];
            });
            services.AddHttpContextAccessor();
            services.AddHttpClient();

            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddOptions<PushNotificationOptions>()
                .Configure(Configuration.GetSection("NotificationHub").Bind)
                .ValidateDataAnnotations();
            services.AddOptions<AuthenticationOptions>()
                .Configure(Configuration.GetSection("Auth:Jwt").Bind)
                .ValidateDataAnnotations();
            services.AddLogging();

            services.AddCors(cors => cors.AddPolicy(name: "app", builder => builder.WithOrigins("http://discoapi20211205192712.azurewebsites.net/swagger/index.html")));

            var mapperConfig = new MapperConfiguration(ms =>
            {
                ms.AddProfile(new MapProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
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
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(u =>
            {
                u.SwaggerEndpoint("1.0/swagger.json", "Disco.Api");
            });
            ILogger logger = loggerFactory.CreateLogger("ClientErrorLogger");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.ApplicationServices.CreateScope();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors(s => s.AllowAnyOrigin());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
