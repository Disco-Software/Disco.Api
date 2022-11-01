using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class FollowerRepository : BaseRepository<UserFollower, int>, IFollowerRepository
    {
        public FollowerRepository(ApiDbContext ctx) : base(ctx)
        {
        }

        public override async Task AddAsync(UserFollower userFollower)
        {
            await _ctx.UserFollowers.AddAsync(userFollower);

            await _ctx.SaveChangesAsync();
        }
        public override async Task<UserFollower> GetAsync(int id)
        {
           return await _ctx.UserFollowers
                .Include(u => u.FollowingAccount)
                .ThenInclude(u => u.User)
                .Include(f => f.FollowerAccount)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
        }
        public override async Task Remove(int id)
        {
          var userFollower = await _ctx.UserFollowers
                .Include(u => u.FollowingAccount)
                .ThenInclude(u => u.User)
                .Include(f => f.FollowerAccount)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
            _ctx.UserFollowers.Remove(userFollower);
            
            await _ctx.SaveChangesAsync();
        }
        public async Task<List<UserFollower>> GetAllAsync(int id, int pageNumber, int pageSize)
        {
            return await _ctx.UserFollowers
                .Include(u => u.FollowingAccount)
                .ThenInclude(u => u.User)
                .Include(p => p.FollowerAccount)
                .ThenInclude(s => s.Stories)
                .Include(f => f.FollowerAccount)
                .ThenInclude(u => u.User)
                .Where(f => f.FollowingAccountId == id)
                .OrderBy(n => n.FollowerAccount.User.UserName)
                .Take((pageNumber - 1) * pageSize)
                .Skip(pageSize)
                .ToListAsync();
        }
    }
}
