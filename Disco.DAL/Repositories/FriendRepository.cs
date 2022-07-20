using Disco.DAL.EF;
using Disco.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories
{
    public class FriendRepository : Base.BaseRepository<Friend, int>
    {
        public FriendRepository(ApiDbContext _ctx) : base(_ctx) { }

        public async Task<int> AddAsync(Friend currentUserFriend)
        {
            ctx.Friends.Add(currentUserFriend);
            currentUserFriend.IsFriend = true;
            await ctx.SaveChangesAsync();
            return currentUserFriend.Id;
        }
        public async Task ConfirmFriendAsync(Friend item)
        {            
            if (item.IsConfirmed == false)
                ctx.Friends.Remove(item);

            item.IsConfirmed = true;
            item.IsFriend = true;
            
            ctx.Friends.Update(item);
            
            await ctx.SaveChangesAsync();
        }

        public override async Task<Friend> Get(int id) =>
            await ctx.Friends
                .Include(u => u.UserProfile)
                .ThenInclude(u => u.User)
                .Include(f => f.ProfileFriend)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();

        public override async Task Remove(int id)
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

        public async Task<List<Friend>> GetAllFriends(int id)
        {
            return await ctx.Friends
                .Include(u => u.UserProfile)
                .ThenInclude(u => u.User)
                .Include(p => p.ProfileFriend)
                .ThenInclude(s => s.Stories)
                .Include(f => f.ProfileFriend)
                .ThenInclude(u => u.User)
                .Where(f => f.UserProfileId == id)
                .ToListAsync();
        }
    }
}
