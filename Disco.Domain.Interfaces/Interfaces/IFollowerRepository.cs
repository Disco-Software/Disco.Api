using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces
{
    public interface IFollowerRepository
    {
        Task AddAsync(UserFollower userFollower);
        Task<UserFollower> GetAsync(int id);
        Task Remove(UserFollower userFollower);
        Task<List<UserFollower>> GetFollowingAsync(int userId);
        Task<List<UserFollower>> GetFollowingAsync(int userId, int pageNumber, int pageSize);
        Task<List<UserFollower>> GetFollowersAsync(int userId);
        Task<List<UserFollower>> GetFollowersAsync(int userId, int pageNumber, int pageSize);
        int GetFollowersCount(int accountId);
        int GetFollowingsCount(int accountId);
    }
}
