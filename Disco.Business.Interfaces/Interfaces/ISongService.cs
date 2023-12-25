using System.Threading.Tasks;
using Disco.Business.Interfaces.Dtos.PostSong.User.CreatePostSong;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ISongService
    {
        public Task<PostSong> CreatePostSongAsync(CreatePostSongRequestDto model);
        public Task RemoveAsync(int songId);
    }
}
