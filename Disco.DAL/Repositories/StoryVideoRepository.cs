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
    public class StoryVideoRepository : IStoryVideoRepository
    {
        private readonly ApiDbContext ctx;

        public StoryVideoRepository(ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task AddAsync(StoryVideo storyVideo)
        {
            await ctx.StoryVideos.AddAsync(storyVideo);
        }

        public async Task Remove(int id)
        {
            var storyVideo = await ctx.StoryVideos
                .Include(s => s.Story)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            ctx.StoryVideos.Remove(storyVideo);

            await ctx.SaveChangesAsync();
        }
    }
}
