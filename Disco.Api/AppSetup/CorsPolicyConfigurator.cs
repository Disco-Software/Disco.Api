using Disco.Business.Constants;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Disco.Api.AppSetup
{
    public static class CorsPolicyConfigurator
    {
        public static IServiceCollection ConfigureCorsPolicy(this IServiceCollection services)
        {
            return services.AddCors(options =>
            {
                options.AddDefaultPolicy(policyBuilder =>
                {
                    policyBuilder.WithOrigins(
                        "https://localhost:7168", 
                        "https://localhost:5168")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }
    }
}
