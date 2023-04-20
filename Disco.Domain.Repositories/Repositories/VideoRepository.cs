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
    public class VideoRepository : BaseRepository<PostVideo, int>, IVideoRepository
    {
        public VideoRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(PostVideo postVideo)
        {
            await _context.PostVideos.AddAsync(postVideo);
        }

        public override async Task Remove(int id)
        {
            var video = await _context.PostVideos
                .Include(p => p.Post)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            
            video.Post.PostVideos.Remove(video);
            _context.PostVideos.Remove(video);

            await _context.SaveChangesAsync();
        }
    }
}
