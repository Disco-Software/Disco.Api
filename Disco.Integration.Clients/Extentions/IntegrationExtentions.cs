using Disco.Integration.Clients.HttpClients;
using Disco.Integration.Interfaces.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Integration.Clients.Extentions
{
    public static class IntegrationExtentions
    {
        public static void AddIntegrations(this IServiceCollection services)
        {
            services.AddHttpClient<IAudDClient, AudDClient>();
            services.AddHttpClient<IFacebookClient, FacebookClient>();
        }
    }
}
