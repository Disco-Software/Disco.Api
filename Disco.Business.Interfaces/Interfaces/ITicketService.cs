﻿using Disco.Business.Interfaces.Enums;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITicketService
    {
        Task CreateAsync(Ticket ticket);
        Task DeleteAsync(Ticket ticket);
        Task<Ticket> GetAsync(int id);
        public Task<Ticket> GetAsync(string name);
        Task<IEnumerable<TicketSummary>> GetAllAsync(int pageNumber, int pageSize, TicketStatusType statusType);
        Task<Ticket> GetTicketAsync(int id);
        Task UpdateAsync(Ticket ticket);
        Task<List<TicketSummary>> SearchAsync(string search, int pageNumber, int pageSize);
        int Count(bool isArchived);
        Task UpdateTicketStatusAsync(Ticket ticket, string status);
    }
}
