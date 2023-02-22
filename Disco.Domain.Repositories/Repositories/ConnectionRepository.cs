using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class ConnectionRepository : BaseRepository<Connection, string>, IConnectionRepository
    {
        public ConnectionRepository(ApiDbContext context) : base(context) { }

        public override async Task AddAsync(Connection connection)
        {
           await base.AddAsync(connection);
        }

        public async Task DeleteAsync(Connection connection)
        {
            await base.Remove(connection);
        }

        public override async Task<Connection> GetAsync(string id)
        {
            return await _context.Connections
                .Where(c => c.Id.Equals(id))
                .FirstOrDefaultAsync() ?? throw new NullReferenceException("Connection not found");
        }

        public override async Task Update(Connection connection)
        {
           await base.Update(connection);
        }
    }
}
