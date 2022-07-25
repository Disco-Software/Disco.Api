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
    public class StoryRepository : BaseRepository<Story, int>, IStoryRepository
    {
        public StoryRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task AddAsync(Story story, Profile profile)
        {
            await _ctx.Stories.AddAsync(story);
           
            profile.Stories.Add(story);

            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Story>> GetAllAsync(int profileId, int pageNumber, int pageSize)
        {
            var storyList = new List<Story>();

            var profile = await _ctx.Profiles
                .Include(u => u.User)
                .Include(u => u.Stories)
                .ThenInclude(s => s.StoryImages)
                .Include(u => u.Stories)
                .ThenInclude(s => s.StoryVideos)
                .Include(f => f.Followers)
                .ThenInclude(p => p.ProfileFriend)
                .ThenInclude(s => s.Stories)
                .ThenInclude(si => si.StoryImages)
                .Include(f => f.Followers)
                .ThenInclude(p => p.ProfileFriend)
                .ThenInclude(p => p.Stories)
                .ThenInclude(s => s.StoryVideos)
                .Include(f => f.Followers)
                .ThenInclude(p => p.UserProfile)
                .Include(f => f.Followers)
                .ThenInclude(p => p.ProfileFriend)
                .ThenInclude(s => s.Stories)
                .ThenInclude(s => s.StoryImages)
                .Include(f => f.Followers)
                .ThenInclude(f => f.ProfileFriend)
                .ThenInclude(f => f.Stories)
                .ThenInclude(f => f.StoryVideos)
                .Where(u => u.Id == profileId)
                .FirstOrDefaultAsync();
            
            storyList.AddRange(profile.Stories);

            foreach (var friend in profile.Followers)
            {
                friend.ProfileFriend = await _ctx.Profiles
                    .Include(p => p.Stories)
                    .ThenInclude(i => i.StoryImages)
                    .Include(p => p.Stories)
                    .ThenInclude(s => s.StoryVideos)
                    .Include(u => u.User)
                    .Where(f => f.Id == friend.FriendProfileId)
                    .FirstOrDefaultAsync();
                storyList.AddRange(friend.ProfileFriend.Stories);
            }

           return storyList.OrderByDescending(d => d.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public override async Task Remove(int id)
        {
            var story = await _ctx.Stories
                .Include(i => i.StoryImages)
                .Include(v => v.StoryVideos)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            story.Profile.Stories.Remove(story);
            _ctx.Stories.Remove(story);
        }

        public override Task<Story> Get(int id)
        {
            var story = _ctx.Stories
                .Include(i => i.StoryImages)
                .Include(v => v.StoryVideos)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            return story;
        }
    }
}
