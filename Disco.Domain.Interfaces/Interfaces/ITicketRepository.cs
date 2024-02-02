using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket, int>
    {
        Task<List<TicketSummary>> GetAllAsync(int pageNumber, int pageSize);
        Task<TicketSummary> GetTicketAsync(int id);
        Task<Ticket> GetTicketAsync(string name);
        int GetTicketsCount();
    }
}
