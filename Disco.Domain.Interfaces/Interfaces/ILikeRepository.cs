using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface ILikeRepository
    {
        Task AddAsync(Like item);
        Task Remove(Like like,int id);
        Task<Like> GetAsync(int postId);
        Task<List<Like>> GetAll(int postId, int pageNumber, int pageSize);
        Task<List<Like>> GetAll(int postId);
    }
}
