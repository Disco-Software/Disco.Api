using Disco.DAL.EF;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Repositories
{
    public class SongRepository : BaseRepository.BaseRepository<Song, int>
    {
        public SongRepository(ApplicationDbContext ef) : base(ef)
        {

        }
    }
}
