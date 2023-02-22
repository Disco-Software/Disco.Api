using Disco.Domain.EF;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApiDbContext _context;

        public RefreshTokenRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<User> GetAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
