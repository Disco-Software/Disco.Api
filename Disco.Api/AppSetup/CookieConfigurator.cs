using System;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class CookieConfigurator
    {
        public static void ConfigureCookie(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.ConfigureApplicationCookie(s =>
            {
                s.Cookie.HttpOnly = true;
                s.ExpireTimeSpan = TimeSpan.FromMinutes(3000);
            });
        }
    }
}
