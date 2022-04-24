using Disco.DAL.EF;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories
{
    public class SongRepository : Base.BaseRepository<PostSong, int>
    {
        public SongRepository(ApiDbContext _ctx) : base(_ctx) { }

        public override async Task Add(PostSong item)
        {
            await ctx.PostSongs.AddAsync(item);
        }
    }
}
