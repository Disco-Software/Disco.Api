using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

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

        public async Task<TicketStatus> UpdateAsync(TicketStatus ticketStatus)
        {
             await _ticketStatusRepository.UpdateAsync(ticketStatus);

            return ticketStatus;
        }
    }
}
