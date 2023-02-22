using Disco.Domain.EF;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class FollowingRepository : BaseRepository<UserFollower, int>, IFollowingRepository
    {
        public FollowingRepository(ApiDbContext context) : base(context) { }

        public IQueryable<UserFollower> GetAll()
        {
            return _context.UserFollowers
                .AsQueryable();
        }
    }
}
