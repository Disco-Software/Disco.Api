using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(
            ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task CreateAsync(Ticket ticket)
        {
            await _ticketRepository.AddAsync(ticket);
        }

        public async Task DeleteAsync(Ticket ticket)
        {
            await _ticketRepository.RemoveAsync(ticket);
        }

        public async Task<IEnumerable<TicketSummary>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _ticketRepository.GetAllAsync(pageNumber, pageSize);
        }

        public Task<Ticket> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> UpdateAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
