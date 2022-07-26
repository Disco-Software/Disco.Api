﻿using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class StoryImageRepository : BaseRepository<StoryImage,int>, IStoryImageRepository
    {
        public StoryImageRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(StoryImage item)
        {
            await ctx.StoriesImages.AddAsync(item);
        }

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
