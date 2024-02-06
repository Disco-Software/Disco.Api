using Disco.Business.Interfaces.Enums;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITicketService
    {
        Task CreateAsync(Ticket ticket);
        Task DeleteAsync(Ticket ticket);
        Task<IEnumerable<TicketSummary>> GetAllAsync(int pageNumber, int pageSize, TicketStatusType statusType);
        Task<TicketSummary> GetAsync(int id);
        Task<Ticket> GetTicketAsync(int id);
        Task UpdateAsync(Ticket ticket);
        int Count();
    }
}
