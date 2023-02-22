using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface IFollowingRepository
    {
        Task AddAsync(UserFollower userFollower);
        Task Remove(UserFollower userFollower);
        Task<UserFollower> GetAsync(int id);
        IQueryable<UserFollower> GetAll();
    }
}
