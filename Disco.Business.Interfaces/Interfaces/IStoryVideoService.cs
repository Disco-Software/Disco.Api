using Disco.Business.Interfaces.Dtos.StoryVideos;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IStoryVideoService
    {
        Task<StoryVideo> CreateStoryVideoAsync(CreateStoryVideoDto model);
        Task Remove(int id);
    }
}
