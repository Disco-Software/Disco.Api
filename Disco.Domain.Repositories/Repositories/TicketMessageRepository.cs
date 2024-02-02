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

        public async Task<List<TicketMessage>> GetAllAsync(int ticketId, int userId, int pageNumber, int pageSize)
        {
            return await _context.TicketMessages
                .Include(x => x.Account)
                .ThenInclude(x => x.User)
                .Where(x => x.TicketId == ticketId && 
                    !(x.IsDeleted == true && 
                    x.Account.UserId == userId))
                .OrderBy(x => x.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
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
