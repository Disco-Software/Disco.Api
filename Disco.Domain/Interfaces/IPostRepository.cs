using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task Remove(int id);
        Task<List<Post>> GetAll(int userId, int pageSize, int pageNumber);
        Task<List<Post>> GetAllUserPosts(int userId, int pageSize, int pageNumber);
        Task<Post> GetAsync(int id);
        Task<List<Post>> GetPostsByDescriptionAsync(string search);
    }
}
