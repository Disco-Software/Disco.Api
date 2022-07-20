using Disco.Domain.EF;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class ImageRepository : Base.BaseRepository<PostImage, int>
    {
        public ImageRepository(ApiDbContext _ctx) : base(_ctx) { }

        public async override Task Add(PostImage item)
        {
            await ctx.PostImages.AddAsync(item);
        }
    }
}
