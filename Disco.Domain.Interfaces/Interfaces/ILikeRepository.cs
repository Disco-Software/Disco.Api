using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces
{
    public interface ILikeRepository : IRepository<Like, int>
    {
        Task<List<Like>> GetAllAsync(int postId, int pageNumber, int pageSize);
        Task<Like> GetAsync(int accountId, int postId);
    }
}
