using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext ctx;

        public UserRepository(ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await ctx.Users
                .Include(p => p.Profile)
                .ThenInclude(p => p.Posts)
                .Include(p => p.Profile)
                .ThenInclude(s => s.Stories)
                .Include(p => p.Profile)
                .ThenInclude(f => f.Followers)
                .FirstOrDefaultAsync();
        }

    }
}
