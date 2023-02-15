using Disco.Business.Constants;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Disco.Business.Services.Extentions
{
    public static class AuthenticationExtentions
    {
        public static void AddUserAuthentication(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddAuthentication()
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
           });
        }
    }
}
