using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task AddAsync(PostImage item);
        Task RemoveAsync(PostImage item);
        Task<PostImage> GetAsync(int id);
    }
}
