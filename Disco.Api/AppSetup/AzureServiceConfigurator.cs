using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class AzureServiceConfigurator
    {
        public static void ConfigureAzureServices(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(configuration.GetConnectionString("BlobStorage"));
            });
        }
    }
}
