using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task AddAsync(PostImage item);
        Task Remove(PostImage item);
        Task<PostImage> GetAsync(int id);
    }
}
