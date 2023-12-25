using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IMessageService
    {
        Task<Message> CreateAsync(string message, Account account, Group group);
        Task DeleteAsync(Message message);
        IEnumerable<Message> GetGroupMessages(int id, int pageNumber, int pageSize);
        Task<List<Message>> GetAllAsync(int groupId, int pageNumber, int pageSize);
        Task<Message> GetByIdAsync(int id);
        Task UpdateAsync(Message message);
    }
}
