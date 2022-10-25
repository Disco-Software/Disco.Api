using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task<int> AddAsync(Message currentUserMessage);
        Task<Message> Get(int id);
        Task Remove(int id);
        Task<List<Message>> GetAllMessages(int id, int pageNumber, int pageSize);
    }
}
