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

        public async Task AddAsync(Story story)
        {
            await _context.Stories.AddAsync(story);
           
            await _context.SaveChangesAsync();
        }

        public async Task<List<Story>> GetAllAsync(int accountId, int pageNumber, int pageSize)
        {
            var storyList = new List<Story>();

            var account = await _context.Accounts.FirstOrDefaultAsync();

            await _context.Entry(account)
                .Collection(account => account.Stories)
                .LoadAsync();

            await _context.Entry(account)
                .Collection(account => account.Following)
                .LoadAsync();

            await _context.Entry(account)
                .Reference(account => account.User)
                .LoadAsync();

            storyList.AddRange(account.Stories);

            foreach (var following in account.Following)
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
                .Where(story => story.DateOfCreation >= DateTime.UtcNow.AddHours(-12))
                .OrderByDescending(story => story.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return stories;
        }

        public async Task RemoveAsync(Story story)
        {
            _context.Stories.Remove(story);

            await _context.SaveChangesAsync();
        }

        public override async Task<Story> GetAsync(int id)
        {
            return await _context.Stories
                .Include(i => i.StoryImages)
                .Include(v => v.StoryVideos)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }
    }
}
