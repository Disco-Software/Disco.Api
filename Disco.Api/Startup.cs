using AutoMapper;
using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.BLL.Mapper;
using Disco.BLL.Services;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Entities.Base;
using Disco.DAL.Interfaces;
using Disco.DAL.Repositories;
using Disco.DAL.Repositories.Base;
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
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
            services.AddSwaggerGen(c => {
                
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "stas_1999_nr@ukr.net",
                        Name = "Станислав",
                        Url = new Uri("https://www.facebook.com/stas.korchevskyy/")
                    },
                    Title = "Disco.Api",
                    Description = "This Api is for front-end and mobile developers who are developing Disco.",
                    Version = "v1",
                });
            });
            services.AddSwaggerGen();
            services.AddDbContext<ApiDbContext>(o => 
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly("../Disco.DAL")));
            services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApiDbContext>();
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApiDbContext>()
                .AddDefaultTokenProviders();

            services.AddOptions<AuthenticationOptions>();

            services.AddAuthentication()
                .AddJwtBearer("MobileJwt", options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidIssuer = Configuration["Auth:Jwt:Issuer"],
                        ValidAudience = Configuration["Auth:Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Convert.FromBase64String(Configuration["Auth:Jwt:SigningKey"]))
                    };
                })
                .AddFacebook(facebookOptions =>
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

            services.AddLogging();


            var mapperConfig = new MapperConfiguration(ms =>
            {
                ms.AddProfile(new MapProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger(c => {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(u =>
            {
                u.SwaggerEndpoint("v1/swagger.json", "Disco.Api");
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.ApplicationServices.CreateScope();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
