﻿using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class StoryImageRepository : BaseRepository<StoryImage,int>, IStoryImageRepository
    {
        public StoryImageRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(StoryImage item)
        {
            await _context.StoryImages.AddAsync(item);
        }

        public override async Task Remove(StoryImage item)
        {
            _context.StoryImages.Remove(item);

            await _context.SaveChangesAsync();
        }
    }
}
