using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApiDbContext ctx;

        public VideoRepository(
            ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task AddAsync(PostVideo postVideo)
        {
            await ctx.PostVideos.AddAsync(postVideo);
        }

        public async Task Remove(int id)
        {
            var video = await ctx.PostVideos
                .Include(p => p.Post)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            
            video.Post.PostVideos.Remove(video);
            ctx.PostVideos.Remove(video);

            await ctx.SaveChangesAsync();
        }
    }
}
