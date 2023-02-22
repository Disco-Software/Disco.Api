using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IStoryVideoRepository
    {
        Task AddAsync(StoryVideo storyVideo);
        Task Remove(StoryVideo storyVideo);
        Task<StoryVideo> GetAsync(int id);
    }
}
