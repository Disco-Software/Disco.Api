using Disco.Business.Dtos.Friends;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IFollowerService
    {
        Task<UserFollower> CreateAsync(User user, User follower, CreateFollowerDto dto);
        Task DeleteAsync(int id);
        Task<List<UserFollower>> GetAllAsync(GetAllFollowersDto dto);
        Task<UserFollower> GetAsync(int id);
    }
}
