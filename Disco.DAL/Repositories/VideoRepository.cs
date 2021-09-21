using Disco.DAL.EF;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Repositories
{
    public class VideoRepository : Base.BaseRepository<PostVideo, int>
    {
        public VideoRepository(ApiDbContext _ctx) : base(_ctx) { }
    }
}
