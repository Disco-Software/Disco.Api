using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task Remove(int id);
        Task<Post> GetAsync(int id);
        Task<List<Post>> GetPostsByDescriptionAsync(string search);
        Task<List<Post>> GetUserPostsAsync(int accountId, int pageNumber, int pageSize);
        List<int> GetPostsCountFromDay(DateTime date); 
        List<int> GetPostsCountFromMonth(DateTime date); 
        List<int> GetPostsCountFromYear(DateTime date); 
        Task<List<Post>> GetUserPostsAsync(int accountId);
        Task<List<Post>> GetAllPostsAsync(DateTime from, DateTime to);
    }
}
