using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITicketMessageService
    {
        Task CreateAsync(TicketMessage message);
        Task DeleteAsync(TicketMessage message);
        Task<IEnumerable<TicketMessage>> GetAllAsync(int pageNumber, int pageSize);
        Task<TicketMessage> GetAsync(TicketMessage message);
        Task<TicketMessage> UpdateAsync(TicketMessage message);
    }
}
