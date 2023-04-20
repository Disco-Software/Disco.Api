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
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }
        
        public async Task Remove(UserFollower userFollower)
        {
            _context.UserFollowers.Remove(userFollower);
            
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserFollower>> GetFollowingAsync(int accountId)
        {
            var followers = await _context.Accounts
                .SelectMany(account => account.Followers)
                .Include(follower => follower.FollowerAccount)
                .ToListAsync();

            return followers;
        }

        public async Task<List<UserFollower>> GetFollowingAsync(int accountId, int pageNumber, int pageSize)
        {
            var followingList = new List<UserFollower>();

            var account = await _context.Accounts
                .Include(account => account.User)
                .Where(account => account.Id == accountId)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();

            await _context.Entry(account)
                .Collection(account => account.Following)
                .LoadAsync();

            foreach (var following in account.Following)
            {
                var followingAccount = await _context.Accounts
                    .FirstAsync(userAccount => userAccount.Id == following.FollowingAccountId);

                await _context.Entry(followingAccount)
                    .Reference(userAccount => userAccount.User)
                    .LoadAsync();

                await _context.Entry(followingAccount)
                    .Collection(userAccount => userAccount.Following)
                    .LoadAsync();

                await _context.Entry(followingAccount)
                    .Collection(userAccount => userAccount.Followers)
                    .LoadAsync();
                
                await _context.Entry(followingAccount)
                    .Collection(userAccount => userAccount.Followers)
                    .LoadAsync();
            }

            followingList.AddRange(account.Following);

            return followingList;
        }


        public async Task<List<UserFollower>> GetFollowersAsync(int accountId)
        {
            var followersList = new List<UserFollower>();

            var account = await _context.Accounts
                .Where(account => account.Id == accountId)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();

            await _context.Entry(account)
                .Collection(account => account.Followers)
                .LoadAsync();

            await _context.Entry(account)
                .Collection(account => account.Posts)
                .LoadAsync();

            foreach (var following in account.Followers)
            {
                following.FollowerAccount = await _context.Accounts
                    .Where(account => account.Id == following.FollowerAccountId)
                    .FirstOrDefaultAsync() ?? throw new NullReferenceException();

                await _context.Entry(following.FollowingAccount)
                    .Reference(account => account.User)
                    .LoadAsync();

                await _context.Entry(following.FollowingAccount)
                    .Collection(account => account.Following)
                    .LoadAsync();

                await _context.Entry(following.FollowingAccount)
                    .Collection(account => account.Followers)
                    .LoadAsync();

            }

            followersList.AddRange(account.Followers);

            return followersList;
        }
        public async Task<List<UserFollower>> GetFollowersAsync(int accountId, int pageNumber, int pageSize)
        {
            var followersList = new List<UserFollower>();

            var account = await _context.Accounts
                .Where(account => account.Id == accountId)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();

            await _context.Entry(account)
                .Collection(account => account.Followers)
                .LoadAsync();

            await _context.Entry(account)
                .Collection(account => account.Posts)
                .LoadAsync();

            foreach (var follower in account.Followers)
            {
                follower.FollowerAccount = await _context.Accounts
                    .Where(account => account.Id == follower.FollowerAccountId)
                    .FirstOrDefaultAsync() ?? throw new NullReferenceException();

                await _context.Entry(follower.FollowingAccount)
                    .Reference(account => account.User)
                    .LoadAsync();

                await _context.Entry(follower.FollowerAccount)
                    .Collection(account => account.Following)
                    .LoadAsync();

                await _context.Entry(follower.FollowerAccount)
                    .Collection(account => account.Followers)
                    .LoadAsync();

            }

            followersList.AddRange(account.Followers);

            return followersList.OrderBy(follower => follower.FollowerAccount.User.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

    }
}
