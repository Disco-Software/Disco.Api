using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Services
{
    public class TicketPriorityService : ITicketPriorityService
    {
        private readonly ITicketPriorityRepository _ticketPriorityRepository;

        public TicketPriorityService(
            ITicketPriorityRepository ticketPriorityRepository)
        {
            _ticketPriorityRepository = ticketPriorityRepository;
        }

        public async Task<TicketPriority> GetAsync(string name)
        {
            var ticketPriority = await _ticketPriorityRepository.GetAsync(name);

            return ticketPriority;
        }
    }
}
