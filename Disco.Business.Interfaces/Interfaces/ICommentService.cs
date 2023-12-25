using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ICommentService
    {
        Task AddCommentAsync(Comment comment);
        Task RemoveCommentAsync(Comment comment);
        Task<Comment> GetCommentAsync(int id);
        Task<List<Comment>> GetAllCommentsAsync(int postId, int pageNumber, int pageSize);
        Task UpdateCommentAsync(Comment comment);
    }
}
