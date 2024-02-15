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
                    Name = ticket.Name,
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

        public async Task<TicketSummary?> GetTicketAsync(int ticketId)
        {
            return await _context.Tickets
                .Include(x => x.Owner)
                .ThenInclude(x => x.User)
                .Include(x => x.Priority)
                .Include(x => x.TicketMessages)
                .AsNoTracking()
                .Select(ticket => new TicketSummary
                {
                    Id = ticket.Id,
                    CreatedDate = ticket.CreationDate,
                    Priority = ticket.Priority.Name,
                    Status = ticket.Status.Name,
                    Owner = new OwnerSummary
                    {
                        Photo = ticket.Owner.Photo ?? "",
                        UserName = ticket.Owner.User.UserName!
                    },
                    IsArchived = ticket.IsArchived,
                })
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }

        public async Task<Ticket> GetTicketAsync(string name)
        {
            var ticket = await _context.Tickets
                .Include(x => x.Owner)
                    .ThenInclude(x => x.User)
                .Include(x => x.TicketMessages)
                .Include(x => x.Administrators) // Предполагаемо, что у Ticket есть навигационное свойство Admins
                    .ThenInclude(x => x.User)
                        .Where(x => x.Name == name)
                .FirstOrDefaultAsync() ?? throw new Exception();


            return ticket;
        }

        public async Task<List<TicketSummary>> SearchAsync(string search, int pageNumber, int pageSize)
        {
            return await _context.Tickets
                .AsNoTracking()
                .OrderByDescending(x => x.Owner.User.UserName)
                .Where(x => x.Owner.User.UserName.StartsWith(search))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(ticket => new TicketSummary
                {
                    Id = ticket.Id,
                    CreatedDate = ticket.CreationDate,
                    Priority = ticket.Priority.Name,
                    Status = ticket.Status.Name,
                    IsArchived = ticket.IsArchived,
                    Owner = new OwnerSummary
                    {
                        UserName = ticket.Owner.User.UserName,
                        Photo = ticket.Owner.Photo
                    }
                })
                .ToListAsync();
        }

        public override async Task<Ticket> GetAsync(int id)
        {
            return await _context.Tickets
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.Owner)
                .ThenInclude(o => o.User)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }

        public async Task<List<TicketSummary>> GetAllArchivedAsync(int pageNumber, int pageSize)
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
                .Where(x => x.IsArchived == true)
                .OrderByDescending(x => x.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async override Task UpdateAsync(Ticket newItem)
        {
           await base.UpdateAsync(newItem);
        }
    }
}
