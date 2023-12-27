using Disco.Business.Interfaces.Dtos.Posts;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(Post post);
        Task<List<Post>> GetAllUserPosts(User user, GetAllPostsDto dto);
        Task<List<Post>> GetAllUserPosts(User user);
        Task DeletePostAsync(int postId);
        Task<Post> GetPostAsync(int id);
        Task<List<Post>> GetPostsByDescriptionAsync(string search);
        Task<List<Post>> GetAllPostsAsync(User user, int pageNumber, int pageSize);
        int GetPostsCount(int accountId);
    }
}
