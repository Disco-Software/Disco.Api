using System;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.ApiServices.Extentions
{
    public static class CookieExtentions
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
