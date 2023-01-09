using Disco.Business.Dtos.Posts;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(Post post);
        Task<List<Post>> GetAllUserPosts(User user, GetAllPostsDto dto);
        Task<List<Post>> GetAllUserPosts(User user);
        Task DeletePostAsync(int postId);
        Task<Post> GetPostAsync(int id);
        Task<List<Post>> GetPostsByDescriptionAsync(string search);
        Task<List<Post>> GetAllPostsAsync(User user);
    }
}
