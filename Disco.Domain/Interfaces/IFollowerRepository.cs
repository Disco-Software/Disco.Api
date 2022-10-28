using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IFollowerRepository
    {
        Task AddAsync(UserFollower userFollower);
        Task<UserFollower> GetAsync(int id);
        Task Remove(int id);
        Task<List<UserFollower>> GetAllAsync(int id, int pageNumber, int pageSize);
    }
}
