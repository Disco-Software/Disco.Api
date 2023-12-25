using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Repositories.Repositories
{
    public class StoryRepository : BaseRepository<Story, int>, IStoryRepository
    {
        public StoryRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task AddAsync(Story story)
        {
            await _context.Stories.AddAsync(story);
           
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Story>> GetAllAsync(int accountId, int pageNumber, int pageSize)
        {
            var storyList = new List<Story?>();

            var currentAccount = await _context.Accounts
                .Include(x => x.Followers)
                .Include(x => x.Following)
                .Where(x => x.Id == accountId)
                .FirstOrDefaultAsync();

            var currentUserStories = await _context.Accounts
                .Include(x => x.Stories)
                .SelectMany(x => x.Stories)
                .Include(x => x.StoryVideos)
                .Include(x => x.StoryImages)
                .Include(x => x.Account)
                .ToListAsync();

            storyList.AddRange(currentUserStories);

            foreach (var following in currentAccount!.Following)
            {
                await _context.Entry(following)
                    .Reference(following => following.FollowingAccount)
                    .LoadAsync();

                await _context.Entry(following.FollowingAccount)
                    .Reference(following => following.User)
                    .LoadAsync();

                await _context.Entry(following.FollowingAccount)
                    .Collection(account => account.Stories)
                    .LoadAsync();

                storyList.AddRange(following.FollowingAccount.Stories);
            }

            var stories = storyList
                .Where(story => story.DateOfCreation >= DateTime.UtcNow.AddHours(-24))
                .OrderByDescending(story => story.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return stories.AsEnumerable()!;
        }

        public async Task RemoveAsync(Story story)
        {
            _context.Stories.Remove(story);

            await _context.SaveChangesAsync();
        }

        public override async Task<Story> GetAsync(int id)
        {
            return await _context.Stories
                .Include(a => a.Account)
                .ThenInclude(a => a.User)
                .Include(i => i.StoryImages)
                .Include(v => v.StoryVideos)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }
    }
}
