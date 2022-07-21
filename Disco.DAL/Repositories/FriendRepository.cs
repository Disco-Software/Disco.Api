using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly ApiDbContext ctx;

        public FriendRepository(ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<int> AddAsync(Friend currentUserFriend)
        {
            ctx.Friends.Add(currentUserFriend);
            
            currentUserFriend.IsFriend = true;
            
            await ctx.SaveChangesAsync();
            
            return currentUserFriend.Id;
        }
        public async Task<Friend> Get(int id) =>
            await ctx.Friends
                .Include(u => u.UserProfile)
                .ThenInclude(u => u.User)
                .Include(f => f.ProfileFriend)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
        public async Task Remove(int id)
        {
          var friend = await ctx.Friends
                .Include(u => u.UserProfile)
                .ThenInclude(u => u.User)
                .Include(f => f.ProfileFriend)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
            ctx.Friends.Remove(friend);
           
            await ctx.SaveChangesAsync();
        }
        public async Task<List<Friend>> GetAllFriends(int id, int pageNumber, int pageSize)
        {
            return await ctx.Friends
                .Include(u => u.UserProfile)
                .ThenInclude(u => u.User)
                .Include(p => p.ProfileFriend)
                .ThenInclude(s => s.Stories)
                .Include(f => f.ProfileFriend)
                .ThenInclude(u => u.User)
                .Where(f => f.UserProfileId == id)
                .OrderBy(n => n.ProfileFriend.User.UserName)
                .Take((pageNumber - 1) * pageSize)
                .Skip(pageSize)
                .ToListAsync();
        }
    }
}
