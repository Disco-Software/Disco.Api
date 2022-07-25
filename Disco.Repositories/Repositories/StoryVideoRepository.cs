using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class StoryVideoRepository : BaseRepository<StoryVideo, int>, IStoryVideoRepository
    {
        public StoryVideoRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(StoryVideo storyVideo)
        {
            await _ctx.StoryVideos.AddAsync(storyVideo);
        }

        public override async Task Remove(int id)
        {
            var storyVideo = await _ctx.StoryVideos
                .Include(s => s.Story)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            _ctx.StoryVideos.Remove(storyVideo);

            await _ctx.SaveChangesAsync();
        }
    }
}
