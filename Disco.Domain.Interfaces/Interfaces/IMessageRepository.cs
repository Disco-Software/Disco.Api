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
        Task AddAsync(Message message, CancellationToken cancellationToken = default);
        Task Remove(Message message, CancellationToken cancellationToken = default);
        IQueryable<Message> GetAll(int pageNumber, int pageSize);
        Task<Message> GetAsync(int id);
        Task UpdateAsync(Message message, CancellationToken cancellationToken = default);
    }
}
