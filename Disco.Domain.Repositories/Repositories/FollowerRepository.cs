using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class FollowerRepository : BaseRepository<UserFollower, int>, IFollowerRepository
    {
        public FollowerRepository(ApiDbContext ctx) : base(ctx)
        {
        }

        public override async Task AddAsync(UserFollower userFollower)
        {
           await base.AddAsync(userFollower);
        }

        public override async Task<UserFollower> GetAsync(int id)
        {
           return await _context.UserFollowers
                .Include(u => u.FollowingAccount)
                .ThenInclude(u => u.User)
                .Include(f => f.FollowerAccount)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException("Follower not found");
        }
        public override async Task Remove(UserFollower userFollower)
        {
            await base.Remove(userFollower);
        }

        public IQueryable<UserFollower> GetAll()
        {
            return _context.UserFollowers
                .Include(userFollower => userFollower.FollowerAccount)
                .Include(UserFollower => UserFollower.FollowingAccount)
                .AsQueryable();
        }
    }
}
