using Azure.Messaging.ServiceBus;
using Disco.Business.Interfaces.Options;
using Disco.Integration.Interfaces.Interfaces;
using Disco.Intergration.EventPublisher.Publisher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Intergration.EventPublisher.Extentions
{
    public static class ServiceBusExtention
    {
        public static IServiceCollection AddServiceBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ServiceBusClient>((provider) =>
            {
                var connectionString = configuration.GetConnectionString("AzureServiceBusConnection");

                return new ServiceBusClient(connectionString);
            });

            return services.AddSingleton<IRecommendationServiceBusPublisher, RecommendationServiceBusPublisher>();
        }
    }
}
