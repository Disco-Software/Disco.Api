using Disco.Domain.EF;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Repositories.Repositories
{
    public class TicketMessageRepository : BaseRepository<TicketMessage, int>, ITicketMessageRepository
    {
        public TicketMessageRepository(ApiDbContext context) : base(context) { }

        public override async Task AddAsync(TicketMessage item)
        {
            await _context.TicketMessages.AddAsync(item);

            await _context.SaveChangesAsync();
        }

        public override async Task<TicketMessage> GetAsync(int id)
        {
            return await _context.TicketMessages
                .Include(x => x.Ticket)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }

        public async Task<List<TicketMessage>> GetAllAsync(int ticketId, int userId, int pageNumber, int pageSize)
        {
            return await _context.TicketMessages
                .Include(x => x.Account)
                .ThenInclude(x => x.User)
                .Where(x => x.TicketId == ticketId)
                .OrderByDescending(x => x.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public int Count(int ticketId)
        {
            return _context.TicketMessages
                .Count(x => x.TicketId == ticketId);
        }

        public override Task RemoveAsync(TicketMessage item)
        {
            return base.RemoveAsync(item);
        }

        public async Task UpdateTicketAsync(TicketMessage newItem)
        {
            _context.TicketMessages.Update(newItem);

            await _context.SaveChangesAsync();
        }
    }
}
