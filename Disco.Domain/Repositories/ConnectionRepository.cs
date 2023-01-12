using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class ConnectionRepository : BaseRepository<Connection, string>, IConnectionRepository
    {
        public ConnectionRepository(ApiDbContext context) : base(context) { }

        public async Task CreateAsync(Connection connection)
        {
            await _ctx.Connections.AddAsync(connection);

            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Connection connection)
        {
            _ctx.Connections.Remove(connection);

            await _ctx.SaveChangesAsync();
        }

        public override Task<Connection> GetAsync(string id)
        {
            return _ctx.Connections
                .Where(c => c.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Connection> UpdateAsync(Connection connection)
        {
            _ctx.Connections.Update(connection);

            await _ctx.SaveChangesAsync();

            return connection;
        }
    }
}
