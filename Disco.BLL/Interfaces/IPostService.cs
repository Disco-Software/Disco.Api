using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IPostService
    {
        Task<Post> AddAsync(Post post);
        Task DeleteAsync(int postId);
        Task<Post> GetAsync(int postId);
        Task<List<Post>> GetAllAsync(string userId);
        Task<Post> UpdateAsync(Post post);

    }
}
