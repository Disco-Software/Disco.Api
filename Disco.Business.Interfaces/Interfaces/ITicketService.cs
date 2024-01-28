using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITicketService
    {
        Task CreateAsync(Ticket ticket);
        Task DeleteAsync(Ticket ticket);
        Task<IEnumerable<TicketSummary>> GetAllAsync(int pageNumber, int pageSize);
        Task<TicketSummary> GetAsync(int id);
        Task UpdateAsync(Ticket ticket);
        int Count();
    }
}
