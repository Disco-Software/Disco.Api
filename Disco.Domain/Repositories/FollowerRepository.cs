using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class FollowerRepository : BaseRepository<UserFollower, int>, IFollowerRepository
    {
        public FollowerRepository(ApiDbContext ctx) : base(ctx)
        {
        }

        public async Task<int> AddAsync(UserFollower currentUserFriend)
        {
            await _ctx.UserFollowers.AddAsync(currentUserFriend);
            
            currentUserFriend.IsFriend = true;
            
            await _ctx.SaveChangesAsync();
            
            return currentUserFriend.Id;
        }
        public override async Task<UserFollower> GetAsync(int id) =>
            await _ctx.UserFollowers
                .Include(u => u.UserAccount)
                .ThenInclude(u => u.User)
                .Include(f => f.AccountFollower)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
        public override async Task Remove(int id)
        {
          var friend = await _ctx.UserFollowers
                .Include(u => u.UserAccount)
                .ThenInclude(u => u.User)
                .Include(f => f.AccountFollower)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
            _ctx.UserFollowers.Remove(friend);
           
            await _ctx.SaveChangesAsync();
        }
        public async Task<List<UserFollower>> GetAllFriends(int id, int pageNumber, int pageSize)
        {
            return await _ctx.UserFollowers
                .Include(u => u.UserAccount)
                .ThenInclude(u => u.User)
                .Include(p => p.AccountFollower)
                .ThenInclude(s => s.Stories)
                .Include(f => f.AccountFollower)
                .ThenInclude(u => u.User)
                .Where(f => f.UserAccountId == id)
                .OrderBy(n => n.AccountFollower.User.UserName)
                .Take((pageNumber - 1) * pageSize)
                .Skip(pageSize)
                .ToListAsync();
        }
    }
}
