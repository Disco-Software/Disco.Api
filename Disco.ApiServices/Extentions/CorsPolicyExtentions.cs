using Disco.Business.Constants;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Disco.Api.AppSetup
{
    public static class CorsPolicyExtentions
    {
        public static IServiceCollection ConfigureCorsPolicy(this IServiceCollection services)
        {
            return services.AddCors(options =>
            {
                options.AddDefaultPolicy(policyBuilder =>
                {
                    policyBuilder.WithOrigins(
                        "http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }
    }
}
