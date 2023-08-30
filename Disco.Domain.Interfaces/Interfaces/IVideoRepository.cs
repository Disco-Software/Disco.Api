using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IVideoRepository
    {
        Task AddAsync(PostVideo postVideo);
        Task RemoveAsync(int id);
    }
}
