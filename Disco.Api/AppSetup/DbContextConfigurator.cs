using Disco.Domain.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class DbContextConfigurator
    {
        public static void ConfigureDbContext(this IServiceCollection serviceDescriptors, string connectionString)
        {
            serviceDescriptors.AddDbContext<ApiDbContext>(o =>
                o.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("../Disco.DAL")));
        }
    }
}
