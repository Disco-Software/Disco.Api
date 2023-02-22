using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface ISongRepository
    {
        Task AddAsync(PostSong song);
        Task Remove(PostSong song);
        Task<PostSong> GetAsync(int id);
    }
}
