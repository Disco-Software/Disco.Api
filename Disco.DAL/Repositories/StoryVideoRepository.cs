using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories
{
    public class StoryVideoRepository : Base.BaseRepository<StoryVideo, int>
    {
        public StoryVideoRepository(ApiDbContext _ctx) : base(_ctx) { }

        public async Task AddAsync(StoryVideo item) =>
            await ctx.StoryVideos.AddAsync(item);

        public override async Task Remove(int id)
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
