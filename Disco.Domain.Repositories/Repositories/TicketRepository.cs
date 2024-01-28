using Disco.Domain.EF;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Repositories.Repositories
{
    public class TicketRepository : BaseRepository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(ApiDbContext context) : base(context) { }

        public async Task<List<TicketSummary>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Tickets
                .Include(x => x.Owner)
                .ThenInclude(x => x.User)
                .AsNoTracking()
                .Select(ticket => new TicketSummary
                {
                    Id = ticket.Id,
                    Owner = new OwnerSummary
                    {
                        Photo = ticket.Owner.Photo,
                        UserName = ticket.Owner.User.UserName,
                    },
                    CreatedDate = ticket.CreationDate,
                    Priority = ticket.Priority.Name,
                    Status = ticket.Status.Name,
                    IsArchived = ticket.Status.IsArchived,
                })
                .Where(x => x.IsArchived == false)
                .OrderByDescending(x => x.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public int GetTicketsCount()
        {
            return _context.Tickets.Count(x => x.IsArchived == false);
        }
    }
}
