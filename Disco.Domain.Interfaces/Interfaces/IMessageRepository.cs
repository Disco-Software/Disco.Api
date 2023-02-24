using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task CreateAsync(Message message, CancellationToken cancellationToken = default);
        Task DeleteAsync(Message message, CancellationToken cancellationToken = default);
        Task<List<Message>> GetAllAsync(int groupId, int pageNumber, int pageSize);
        Task<Message> GetByIdAsync(int id);
        Task UpdateAsync(Message message, CancellationToken cancellationToken = default);
    }
}
