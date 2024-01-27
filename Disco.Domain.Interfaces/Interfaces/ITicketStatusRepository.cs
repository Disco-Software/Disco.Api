using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface ITicketStatusRepository : IRepository<TicketStatus, int>
    {
        Task<TicketStatus> GetAsync(string name);
    }
}
