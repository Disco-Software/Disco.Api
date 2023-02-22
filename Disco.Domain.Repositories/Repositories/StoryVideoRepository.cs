using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class StoryVideoRepository : BaseRepository<StoryVideo, int>, IStoryVideoRepository
    {
        public StoryVideoRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(StoryVideo storyVideo)
        {
            await _context.StoryVideos.AddAsync(storyVideo);
        }

        public override async Task Remove(StoryVideo item)
        {
           await base.Remove(item);
        }

        public override async Task<StoryVideo> GetAsync(int id)
        {
            return await _context.StoryVideos
                .Include(storyVideo => storyVideo.Story)
                .Where(storyVideo => storyVideo.Id == id)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }
    }
}
