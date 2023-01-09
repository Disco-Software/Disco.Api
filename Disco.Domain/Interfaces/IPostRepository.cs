using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task Remove(int id);
        Task<List<Post>> GetFollowersPostsAsync(List<UserFollower> followers);
        Task<List<Post>> GetFollowingPostsAsync(List<UserFollower> following);
        Task<Post> GetAsync(int id);
        Task<List<Post>> GetPostsByDescriptionAsync(string search);
        Task<List<Post>> GetUserPostsAsync(int userId);
    }
}
