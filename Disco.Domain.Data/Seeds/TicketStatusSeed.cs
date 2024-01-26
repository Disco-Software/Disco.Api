using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Data.Seeds
{
    public static class TicketStatusSeed
    {
        public static void AddTicketStatusSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketStatus>().HasData(new TicketStatus[]
            {
                new TicketStatus { Id = 1, Name = "Open", IsArchived = false },
                new TicketStatus { Id = 2, Name = "In Progress", IsArchived = false },
                new TicketStatus { Id = 3, Name = "Closed", IsArchived = true },
            });
        }
    }
}
