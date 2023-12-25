using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task RemoveAsync(Post post);
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
