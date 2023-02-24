using Disco.Business.Interfaces.Dtos.StoryImages;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IStoryImageService
    {
        Task<StoryImage> CreateStoryImageAsync(CreateStoryImageDto model);
        Task RemoveStoryImageAsync(int id);
    }
}
