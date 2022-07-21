using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class ImageRepository : BaseRepository<PostImage, int>, IImageRepository
    {
        public ImageRepository(ApiDbContext _ctx) : base(_ctx) { }

        public override async Task Remove(int id)
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
