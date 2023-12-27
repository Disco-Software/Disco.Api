using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IFollowerService
    {
        Task CreateAsync(UserFollower userFollower);
        Task DeleteAsync(int id);
        Task<List<UserFollower>> GetFollowingAsync(int userId);
        Task<List<UserFollower>> GetFollowingAsync(int userId, int pageNumber, int pageSize);
        Task<List<UserFollower>> GetFollowersAsync(int userId);
        Task<List<UserFollower>> GetFollowersAsync(int userId, int pageNumber, int pageSize);
        Task<UserFollower> GetAsync(int id);
        int GetFollowersCount(int accountId);
        int GetFollowingCount(int accountId);
    }
}
