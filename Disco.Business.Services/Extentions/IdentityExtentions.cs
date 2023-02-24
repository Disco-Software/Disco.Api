using Disco.Domain.EF;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Business.Services.Extentions
{
    public static class IdentityExtentions
    {
        public static void AddUserIdentity(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            }).AddRoles<Role>()
           .AddEntityFrameworkStores<ApiDbContext>();
            serviceDescriptors.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApiDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
