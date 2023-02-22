using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class StoryRepository : BaseRepository<Story, int>, IStoryRepository
    {
        public StoryRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(Story item)
        {
            await _context.Stories.AddAsync(item);
           
            await _context.SaveChangesAsync();
        }

        public async Task<List<Story>> GetAllAsync(int accountId, int pageNumber, int pageSize)
        {
            var storyList = new List<Story>();

            var profile = await _context.Accounts
                .Include(u => u.User)
                .Include(u => u.Stories)
                .ThenInclude(s => s.StoryImages)
                .Include(u => u.Stories)
                .ThenInclude(s => s.StoryVideos)
                .Include(f => f.Followers)
                .ThenInclude(p => p.FollowerAccount)
                .ThenInclude(s => s.Stories)
                .ThenInclude(si => si.StoryImages)
                .Include(f => f.Followers)
                .ThenInclude(p => p.FollowerAccount)
                .ThenInclude(p => p.Stories)
                .ThenInclude(s => s.StoryVideos)
                .Include(f => f.Followers)
                .ThenInclude(p => p.FollowingAccount)
                .Include(f => f.Followers)
                .ThenInclude(p => p.FollowerAccount)
                .ThenInclude(s => s.Stories)
                .ThenInclude(s => s.StoryImages)
                .Include(f => f.Followers)
                .ThenInclude(f => f.FollowerAccount)
                .ThenInclude(f => f.Stories)
                .ThenInclude(f => f.StoryVideos)
                .Where(u => u.Id == accountId)
                .FirstOrDefaultAsync();
            
            storyList.AddRange(profile.Stories);

            foreach (var friend in profile.Followers)
            {
                friend.FollowerAccount = await _context.Accounts
                    .Include(p => p.Stories)
                    .ThenInclude(i => i.StoryImages)
                    .Include(p => p.Stories)
                    .ThenInclude(s => s.StoryVideos)
                    .Include(u => u.User)
                    .Where(f => f.Id == friend.FollowerAccountId)
                    .FirstOrDefaultAsync();
                storyList.AddRange(friend.FollowerAccount.Stories);
            }

           return storyList.OrderByDescending(d => d.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public override async Task Remove(Story item)
        {
           await base.Remove(item);
        }

        public override async Task<Story> GetAsync(int id)
        {
            return await _context.Stories
                .Include(i => i.StoryImages)
                .Include(v => v.StoryVideos)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync() 
                ?? throw new NullReferenceException("story not found");
        }
    }
}
