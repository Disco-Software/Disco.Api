using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITicketPriorityService
    {
        Task<TicketPriority> GetAsync(string name);
    }
}
