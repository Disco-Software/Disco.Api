using Disco.DAL.EF;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories
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
