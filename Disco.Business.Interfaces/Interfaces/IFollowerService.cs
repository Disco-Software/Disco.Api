using Disco.Business.Interfaces.Dtos.Followers;
using Disco.Business.Interfaces.Dtos.Friends;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IFollowerService
    {
        Task<FollowerResponseDto> CreateAsync(User user, User follower, CreateFollowerDto dto);
        Task DeleteAsync(int id);
        Task<List<FollowerResponseDto>> GetAllAsync(GetAllFollowersDto dto);
        Task<List<UserFollower>> GetFollowingAsync(int userId);
        Task<List<UserFollower>> GetFollowersAsync(int userId);
        Task<FollowerResponseDto> GetAsync(int id);
    }
}
