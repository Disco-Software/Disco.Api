using Disco.Domain.EF;
using Disco.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class StoryImageRepository : Base.BaseRepository<StoryImage,int>
    {
        public StoryImageRepository(ApiDbContext _ctx) : base(_ctx) { }

        public async Task AddAsync(StoryImage item) =>
           await ctx.StoriesImages.AddAsync(item);

        public override async Task Remove(int id)
        {
           var storyImage = await ctx.StoriesImages
                .Include(s => s.Story)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            
            storyImage.Story.StoryImages.Remove(storyImage);

            ctx.StoriesImages.Remove(storyImage);

            await ctx.SaveChangesAsync();
        }
    }
}
