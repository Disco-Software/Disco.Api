using Disco.Business.Interfaces.Dtos.PostVideo.User.CreatePostVideo;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IVideoService
    {
        Task<PostVideo> CreateVideoAsync(CreatePostVideoRequestDto model);
        Task RemoveVideoAsync(int id);
    }
}
