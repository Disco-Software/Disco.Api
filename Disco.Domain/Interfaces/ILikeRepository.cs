using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface ILikeRepository
    {
        Task AddAsync(Like item, int postId);
        Task Remove(int id);
        Task<List<Like>> GetAll(int postId);
    }
}
