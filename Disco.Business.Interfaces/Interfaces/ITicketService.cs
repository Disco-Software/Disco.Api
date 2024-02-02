using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITicketService
    {
        Task CreateAsync(Ticket ticket);
        Task DeleteAsync(Ticket ticket);
        public Task<Ticket> GetAsync(int id);
        public Task<Ticket> GetAsync(string name);
        Task UpdateAsync(Ticket ticket);
        int Count();
    }
}
