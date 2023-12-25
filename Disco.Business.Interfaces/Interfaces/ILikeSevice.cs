using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ILikeService
    {
        Task CreateLikeAsync(Like like);
        Task DeleteLikeAsync(Like like);
        Task<List<Like>> GetAllLikesAsync(int postId, int pageNumber, int pageSize);
        Task<Like> GetAsync(int accountId, int postId);
    }
}
