﻿using Disco.Domain.Models;
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
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Message>> GetAllAsync(int mssageId, int groupId, int pageNumber, int pageSize);
        Task<Message> GetByIdAsync(int id);
        Task UpdateAsync(Message message, CancellationToken cancellationToken = default);
    }
}