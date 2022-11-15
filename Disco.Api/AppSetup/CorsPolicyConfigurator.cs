using Disco.Business.Constants;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class CorsPolicyConfigurator
    {
        public static void Configure(CorsPolicyBuilder builder)
        {
            builder.WithOrigins(
                 "https://admin.disco.net.ua",
                 "https://disco.net.ua",
                 "http://localhost:5168",
                 "http://localhost:7168")
                .AllowAnyHeader()
               //.AllowCredentials()
               //.AllowAnyOrigin()
               .AllowAnyMethod();
                
        }
    }
}
