using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Repositories.Repositories
{
    public class ConnectionRepository : BaseRepository<Connection, string>, IConnectionRepository
    {
        public ConnectionRepository(ApiDbContext context) : base(context) { }

        public async Task CreateAsync(Connection connection)
        {
            await _context.Connections.AddAsync(connection);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Connection connection)
        {
            _context.Connections.Remove(connection);

            await _context.SaveChangesAsync();
        }

        public override Task<Connection> GetAsync(string id)
        {
            return _context.Connections
                .Where(c => c.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Connection> UpdateAsync(Connection connection)
        {
            _context.Connections.Update(connection);

            await _context.SaveChangesAsync();

            return connection;
        }
    }
}
