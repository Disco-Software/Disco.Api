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
    public class ImageRepository : BaseRepository<PostImage, int>, IImageRepository
    {
        public ImageRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(PostImage item)
        {
            await _context.PostImages.AddAsync(item);
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
