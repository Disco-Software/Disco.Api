using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Data.Seeds
{
    public static class TicketPrioritySeed
    {
        public static void AddTicketPrioritySeed(this ModelBuilder builder)
        {
            builder.Entity<TicketPriority>().HasData(new TicketPriority[]
            {
                new TicketPriority { Id = 1, Name = "High", Priority = 1 },
                new TicketPriority { Id = 2, Name = "Medium", Priority = 2 },
                new TicketPriority { Id = 3, Name = "Low", Priority = 3 }
            });
        }
    }
}
