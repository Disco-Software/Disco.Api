using Disco.Business.Dtos.StoryVideos;
using Disco.Domain.Models;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IStoryVideoService
    {
        Task<StoryVideo> CreateStoryVideoAsync(CreateStoryVideoDto model);
        Task Remove(int id);
    }
}
