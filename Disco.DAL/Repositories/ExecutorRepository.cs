using Disco.DAL.EF;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Repositories
{
    public class ExecutorRepository : BaseRepository.BaseRepository<Executor, int>
    {
        public ExecutorRepository(ApplicationDbContext ef) : base(ef)
        {

        }
    }
}
