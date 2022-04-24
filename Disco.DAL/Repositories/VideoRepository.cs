using Disco.DAL.EF;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories
{
    public class VideoRepository : Base.BaseRepository<PostVideo, int>
    {
        public VideoRepository(ApiDbContext _ctx) : base(_ctx) { }

        public override async Task Add(PostVideo item)
        {
            await ctx.PostVideos.AddAsync(item);
        }
    }
}
