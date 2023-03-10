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
           return await _ctx.UserFollowers
                .Include(u => u.FollowingAccount)
                .ThenInclude(u => u.User)
                .Include(f => f.FollowerAccount)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }
        
        public async Task Remove(UserFollower userFollower)
        {
            _ctx.UserFollowers.Remove(userFollower);
            
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<UserFollower>> GetFollowingAsync(int accountId)
        {
            var followers = await _ctx.Accounts
                .SelectMany(account => account.Followers)
                .Include(follower => follower.FollowerAccount)
                .ToListAsync();

            return followers;
        }

        public async Task<List<UserFollower>> GetFollowingAsync(int accountId, int pageNumber, int pageSize)
        {
            var following = await _ctx.UserFollowers
                .Include(f => f.FollowingAccount)
                .ThenInclude(a => a.User)
                .Include(f => f.FollowingAccount)
                .ThenInclude(a => a.AccountStatus)
                .Include(f => f.FollowerAccount)
                .ThenInclude(a => a.User)
                .Include(f => f.FollowerAccount)
                .ThenInclude(a => a.AccountStatus)
                .Where(u => u.FollowerAccountId == accountId)
                .OrderBy(f => f.FollowingAccount.User.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return following;
        }


        public async Task<List<UserFollower>> GetFollowersAsync(int accountId)
        {
            var followers = await _ctx.Accounts
                .SelectMany(account => account.Followers)
                .Include(follower => follower.FollowerAccount)
                .ToListAsync();

            return followers;
        }
        public async Task<List<UserFollower>> GetFollowersAsync(int accountId, int pageNumber, int pageSize)
        {
           return await _ctx.UserFollowers
                .Include(f => f.FollowerAccount)
                .ThenInclude(a => a.User)
                .Include(f => f.FollowerAccount.AccountStatus)
                .Include(f => f.FollowingAccount.AccountStatus)
                .Include(f => f.FollowingAccount)
                .ThenInclude(a => a.User)
                .Where(f => f.FollowingAccountId == accountId)
                .OrderBy(f => f.FollowingAccount.User.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

    }
}
