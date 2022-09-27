using Disco.Business.Dtos.Posts;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IPostService
    {
        Task<Post> CreatePostAsync(User user, CreatePostDto model);
        Task<List<Post>> GetAllUserPosts(User user, GetAllPostsDto model);
        Task<List<Post>> GetAllPosts(User user,GetAllPostsDto model);
        Task DeletePostAsync(int postId);
        Task<Post> GetPostAsync(int id);
        Task<List<Post>> SearchPostsAsync(string search);
    }
}
