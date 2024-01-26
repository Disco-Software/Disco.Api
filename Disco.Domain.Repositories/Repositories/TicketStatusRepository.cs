using Disco.Domain.EF;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;

namespace Disco.Domain.Repositories.Repositories
{
    public class TicketStatusRepository : BaseRepository<TicketStatus, int>, ITicketStatusRepository
    {
        public TicketStatusRepository(ApiDbContext context) : base(context) { }
    }
}
