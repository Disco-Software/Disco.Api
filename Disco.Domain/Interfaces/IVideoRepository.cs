using Disco.Domain.Models;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IVideoRepository
    {
        Task AddAsync(PostVideo postVideo);
        Task Remove(int id);
    }
}
