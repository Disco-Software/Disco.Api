using System.Threading.Tasks;
using Disco.Business.Dto.Songs;
using Disco.Domain.Models;

namespace Disco.Business.Interfaces
{
    public interface ISongService
    {
        public Task<PostSong> CreatePostSongAsync(CreateSongDto model);
        public Task Remove(int songId);
    }
}
