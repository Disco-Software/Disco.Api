using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Repositories.Repositories.Base;
using Disco.Domain.Models.Models;
using Disco.Domain.EF;

namespace Disco.Domain.Repositories.Repositories
{
    public class TicketDetailsRepository : BaseRepository<TicketDetails, int>, ITicketDetailsRepository
    {
        public TicketDetailsRepository(ApiDbContext context) : base(context) { }
    }
}
