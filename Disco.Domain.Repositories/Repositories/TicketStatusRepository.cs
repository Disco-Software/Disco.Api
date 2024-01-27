using Disco.Domain.EF;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Repositories.Repositories
{
    public class TicketStatusRepository : BaseRepository<TicketStatus, int>, ITicketStatusRepository
    {
        public TicketStatusRepository(ApiDbContext context) : base(context) { }

        public async Task<TicketStatus> GetAsync(string name)
        {
            return await _context.TicketStatuses
                .Where(t => t.Name == name)
                .FirstOrDefaultAsync() ?? 
                throw new NullReferenceException();
        }
    }
}
