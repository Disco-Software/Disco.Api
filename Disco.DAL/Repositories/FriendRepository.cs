using Disco.DAL.EF;
using Disco.DAL.Entities;
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

        public override async Task Add(Friend item)
        {
            await ctx.Friends.AddAsync(item);
            item.UserProfile.Friends.Add(item);
            item.IsFriend = true;
            await ctx.SaveChangesAsync();
        }
        public async Task ConfirmFriendAsync(Friend item)
        {
            item.ProfileFriend.Friends.Add(item);
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
                .Include(f => f.ProfileFriend)
                .ThenInclude(u => u.User)
                .Where(f => f.UserProfileId == id)
                .ToListAsync();
        }
    }
}
