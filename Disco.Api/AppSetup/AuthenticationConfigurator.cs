using Disco.Business.Constants;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Disco.Api.AppSetup
{
    public static class AuthenticationConfigurator
    {
        public static void ConfigureAuthentication(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
           .AddCookie()
          .AddJwtBearer(AuthSchema.UserToken, options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateIssuerSigningKey = true,
                   ValidateLifetime = true,
                   ValidIssuer = configuration["Auth:Jwt:Issuer"],
                   ValidAudience = configuration["Auth:Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(
                   Convert.FromBase64String(configuration["Auth:Jwt:SigningKey"]))
               };
           }).AddFacebook(facebookOptions =>
           {
               facebookOptions.AppId = configuration["Facebook:AppId"];
               facebookOptions.AppSecret = configuration["Facebook:SecretKey"];
           })
           .AddGoogleOpenIdConnect(options =>
           {
               options.ClientId = "365798654865-7o3ea5o4rmj9uoo3dltua3nm3igh64ar.apps.googleusercontent.com";
               options.ClientSecret = "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";
           });
        }
    }
}
