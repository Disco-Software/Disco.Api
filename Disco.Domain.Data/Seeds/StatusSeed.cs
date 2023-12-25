using Disco.Domain.EF;
using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Data.Seeds
{
    public static class StatusSeed
    {
        public static void AddStatusSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .HasData(new Status[]
                {
                   new Status { Id = 1, LastStatus = "Newbie", FollowersCount = 0, NextStatusId = 2, UserTarget = 50 },
                   new Status { Id = 2, LastStatus = "Music lover", FollowersCount = 50, NextStatusId = 3, UserTarget = 500 },
                });
        }
    }
}
