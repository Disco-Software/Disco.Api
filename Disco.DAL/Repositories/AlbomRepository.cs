using Disco.DAL.EF;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Repositories
{
    public class AlbomRepository : BaseRepository.BaseRepository<Album, int>
    {
        public AlbomRepository(ApplicationDbContext ef) : base(ef)
        {

        }
    }
}
