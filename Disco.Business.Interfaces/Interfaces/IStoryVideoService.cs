using Disco.Business.Interfaces.Dtos.StoryVideos.User.CreateStoryVideo;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IStoryVideoService
    {
        Task<StoryVideo> CreateStoryVideoAsync(CreateStoryVideoRequestDto dto);
        Task Remove(int id);
    }
}
