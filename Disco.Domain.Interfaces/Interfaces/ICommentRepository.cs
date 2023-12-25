using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        Task<List<Comment>> GetAllAsync(int postId, int pageNumber, int pageSize);
    }
}
