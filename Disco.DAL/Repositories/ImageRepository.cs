using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApiDbContext ctx;

        public ImageRepository(ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task AddAsync(PostImage item)
        {
            await ctx.PostImages.AddAsync(item);
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
