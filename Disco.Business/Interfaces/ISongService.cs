using System.Threading.Tasks;
using Disco.Business.Dtos.Songs;
using Disco.Domain.Models;

namespace Disco.Business.Interfaces
{
    public interface ISongService
    {
        public Task<PostSong> CreatePostSongAsync(CreateSongDto model);
        public Task Remove(int songId);
    }
}
