using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITicketSummaryService
    {
        Task<IEnumerable<TicketSummary>> GetAllAsync(int pageNumber, int pageSize);
        public Task<TicketSummary> GetAsync(int id);
    }
}
