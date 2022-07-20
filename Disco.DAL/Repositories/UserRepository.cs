using Disco.DAL.EF;
using Disco.DAL.Models;
using Disco.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories
{
    public class UserRepository
    {
        private readonly ApiDbContext ctx;

        public UserRepository(ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken) =>
            await ctx.Users
                .Include(p => p.Profile)
                .ThenInclude(p => p.Posts)
                .Include(p => p.Profile)
                .ThenInclude(s => s.Stories)
                .Include(p => p.Profile)
                .ThenInclude(f => f.Followers)
                .FirstOrDefaultAsync();

    }
}
