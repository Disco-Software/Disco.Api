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
    public class TicketStatusService : ITicketStatusService
    {
        private readonly ITicketStatusRepository _ticketStatusRepository;

        public TicketStatusService(
            ITicketStatusRepository ticketStatusRepository)
        {
            _ticketStatusRepository = ticketStatusRepository;
        }

        public async Task<TicketStatus> GetAsync(string name)
        {
            var ticketStatus = await _ticketStatusRepository.GetAsync(name);

            return ticketStatus;
        }
    }
}
