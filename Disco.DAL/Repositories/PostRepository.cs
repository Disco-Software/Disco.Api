using Disco.DAL.EF;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Repositories
{
    public class PostRepository : BaseRepository.BaseRepository<Post,int>
    {
        public PostRepository(ApplicationDbContext ctx) : base(ctx)
        {
            
        }
    }
}
