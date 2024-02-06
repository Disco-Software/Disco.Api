using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface ITicketMessageRepository : IRepository<TicketMessage, int>
    {
        Task<List<TicketMessage>> GetAllAsync(int ticketId, int userId, int pageNumber, int pageSize);
        Task UpdateTicketAsync(TicketMessage newItem);
    }
}
