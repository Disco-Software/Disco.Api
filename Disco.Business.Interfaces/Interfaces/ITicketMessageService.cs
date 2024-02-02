using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITicketMessageService
    {
        Task CreateAsync(TicketMessage message);
        Task DeleteAsync(TicketMessage message);
        Task DeleteForSenderAsync(TicketMessage message);
        Task<IEnumerable<TicketMessage>> GetAllAsync(int ticketId, int userId, int pageNumber, int pageSize);
        Task<TicketMessage> GetAsync(int id);
        Task UpdateAsync(TicketMessage message);
    }
}
