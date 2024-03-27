using Disco.Business.Interfaces.Enums;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class TicketService : 
        ITicketService, 
        ITicketSummaryService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketStatusRepository _ticketStatusRepository;
        private readonly ITicketDetailsRepository _ticketDetailsRepository;

        public TicketService(
            ITicketRepository ticketRepository, 
            ITicketStatusRepository ticketStatusRepository,
            ITicketDetailsRepository ticketDetailsRepository)
        {
            _ticketRepository = ticketRepository;
            _ticketStatusRepository = ticketStatusRepository;
            _ticketDetailsRepository = ticketDetailsRepository;
        }

        public async Task CreateAsync(Ticket ticket)
        {
            ticket.Owner.CreatedTickets.Add(ticket);

            await _ticketRepository.AddAsync(ticket);
        }

        public async Task DeleteAsync(Ticket ticket)
        {
            ticket.Owner.CreatedTickets.Remove(ticket);

            await _ticketRepository.RemoveAsync(ticket);
        }

        public async Task<IEnumerable<TicketSummary>> GetAllAsync(int pageNumber, int pageSize, TicketStatusType statusType)
        {
            switch (statusType)
            {
                case TicketStatusType.Active:
                    return await _ticketRepository.GetAllAsync(pageNumber, pageSize);
                case TicketStatusType.Archived:
                    return await _ticketRepository.GetAllArchivedAsync(pageNumber,pageSize);
                default:
                    return await _ticketRepository.GetAllAsync(pageNumber, pageSize);
            }
        }

        async Task<TicketSummary> ITicketSummaryService.GetAsync(int id)
        {
            var ticket = await _ticketRepository.GetTicketAsync(id);

            return ticket;
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            await _ticketStatusRepository.UpdateAsync(ticket.Status);

            await _ticketRepository.UpdateAsync(ticket);
        }

        public int Count()
        {
            return _ticketRepository.GetTicketsCount();
        }

        public async Task<List<TicketSummary>> SearchAsync(string search, int pageNumber, int pageSize)
        {
            var tickets = await _ticketRepository.SearchAsync(search, pageNumber, pageSize);

            return tickets;
        }

        public async Task<Ticket> GetTicketAsync(int id)
        {
            var ticket = await _ticketRepository.GetAsync(id);

            return ticket;
        }

        async Task<Ticket> ITicketService.GetAsync(int id)
        {
            var ticket = await _ticketRepository.GetAsync(id);

            return ticket;
        }

        public async Task<Ticket> GetAsync(string name)
        {
            var ticket = await _ticketRepository.GetTicketAsync(name);

            return ticket;
        }

        public async Task<IEnumerable<TicketSummary>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _ticketRepository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task UpdateTicketStatusAsync(Ticket ticket, string status)
        {
            ticket.Status = await _ticketStatusRepository.GetAsync(status);
            var ticketDetails = await _ticketDetailsRepository.GetAsync(ticket.Id);

            ticketDetails.Status = status;

            await _ticketStatusRepository.UpdateAsync(ticket.Status);
            await _ticketDetailsRepository.UpdateAsync(ticketDetails);

            await _ticketRepository.UpdateAsync(ticket);
        }
    }
}
