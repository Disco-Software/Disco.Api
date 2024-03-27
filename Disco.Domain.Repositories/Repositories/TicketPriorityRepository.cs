using Disco.Domain.EF;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Repositories.Repositories
{
    public class TicketPriorityRepository : BaseRepository<TicketPriority, int>, ITicketPriorityRepository
    {
        public TicketPriorityRepository(ApiDbContext context) : base(context) { }

        public async Task<TicketPriority> GetAsync(string name)
        {
            return await _context.TicketPriorities
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync() ?? 
                throw new NullReferenceException();
        }
    }
}
