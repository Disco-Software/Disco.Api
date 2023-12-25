using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces
{
    public interface IMessageRepository : IRepository<Message, int>
    {
        Task CreateAsync(Message message, CancellationToken cancellationToken = default);
        Task DeleteAsync(Message message, CancellationToken cancellationToken = default);
        Task<List<Message>> GetAllAsync(int groupId, int pageNumber, int pageSize);
        Task<Message> GetByIdAsync(int id);
        Task UpdateAsync(Message message, CancellationToken cancellationToken = default);
        IEnumerable<Message> GetAllGroupMessages(int groupId, int pageNumber, int pageSize);
    }
}
