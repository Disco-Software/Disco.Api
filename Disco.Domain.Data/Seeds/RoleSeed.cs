using Disco.Domain.EF;
using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Data.Seeds
{
    public static class RoleSeed
    {
        public static void AddRoleSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role[]
                {
                   new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                   new Role { Id = 2, Name = "User", NormalizedName = "USER" }
                });
        }

    }
}
