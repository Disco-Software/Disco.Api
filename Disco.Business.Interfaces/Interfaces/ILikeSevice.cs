using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ILikeService
    {
        Task<List<Like>> AddLikeAsync(User user, Post post);
        Task<List<Like>> RemoveLikeAsync(User user, Post post);
        Task<List<Like>> GetAllLikesAsync(int postId, int pageNumber, int pageSize);
        Task<List<Like>> GetAllLikesAsync(int postId);
    }
}
