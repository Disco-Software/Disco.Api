using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task AddAsync(Post post, User user);
        Task Remove(int id);
        Task<List<Post>> GetAllPosts(int userId, int pageSize, int pageNumber);
        Task<List<Post>> GetAllUserPosts(int userId, int pageSize, int pageNumber);
        Task<Post> Get(int id);
    }
}
