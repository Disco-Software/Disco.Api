using Disco.Business.Interfaces.Dtos.StoryImages.User.CreateStoryImage;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IStoryImageService
    {
        Task<StoryImage> CreateStoryImageAsync(CreateStoryImageRequestDto model);
        Task RemoveStoryImageAsync(int id);
    }
}
