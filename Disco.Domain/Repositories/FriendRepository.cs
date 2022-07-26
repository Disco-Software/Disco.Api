﻿using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class FriendRepository : BaseRepository<Friend, int>, IFriendRepository
    {
        public FriendRepository(ApiDbContext ctx) : base(ctx)
        {
        }

        public async Task<int> AddAsync(Friend currentUserFriend)
        {
            await _ctx.Friends.AddAsync(currentUserFriend);
            
            currentUserFriend.IsFriend = true;
            
            await _ctx.SaveChangesAsync();
            
            return currentUserFriend.Id;
        }
        public override async Task<Friend> Get(int id) =>
            await _ctx.Friends
                .Include(u => u.UserProfile)
                .ThenInclude(u => u.User)
                .Include(f => f.ProfileFriend)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
        public override async Task Remove(int id)
        {
          var friend = await _ctx.Friends
                .Include(u => u.UserProfile)
                .ThenInclude(u => u.User)
                .Include(f => f.ProfileFriend)
                .ThenInclude(f => f.User)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
            _ctx.Friends.Remove(friend);
           
            await _ctx.SaveChangesAsync();
        }
        public async Task<List<Friend>> GetAllFriends(int id, int pageNumber, int pageSize)
        {
            return await _ctx.Friends
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