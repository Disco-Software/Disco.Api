using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IFollowerRepository
    {
        Task<int> AddAsync(UserFollower currentUserFriend);
        Task<UserFollower> Get(int id);
        Task Remove(int id);
        Task<List<UserFollower>> GetAllFriends(int id, int pageNumber, int pageSize);
    }
}
