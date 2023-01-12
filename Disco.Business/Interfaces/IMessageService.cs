﻿using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IMessageService
    {
        Task<Message> CreateAsync(string message, Account account, Group group);
        Task DeleteAsync(Message message);
        Task<List<Message>> GetAllAsync(int groupId, int pageNumber, int pageSize);
        Task<Message> GetByIdAsync(int id);
        Task UpdateAsync(Message message);
    }
}
