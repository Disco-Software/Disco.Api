using Disco.Domain.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Domain.Data.Extentions
{
    public static class DbContextExtentions
    {
        public static void AddApiDbContext(this IServiceCollection serviceDescriptors, string connectionString)
        {
            serviceDescriptors.AddDbContext<ApiDbContext>(opt => opt.UseSqlServer(connectionString));
        }
    }
}
