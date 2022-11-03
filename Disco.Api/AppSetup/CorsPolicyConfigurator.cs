using Disco.Business.Constants;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class CorsPolicyConfigurator
    {
        public static void Configure(CorsPolicyBuilder builder)
        {
             builder.AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .WithOrigins(
                 "https://admin.disco.net.ua",
                 "https://disco.net.ua");
        }
    }
}
