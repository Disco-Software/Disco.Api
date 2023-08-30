using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IStoryImageRepository
    {
        Task AddAsync(StoryImage storyImage);
        Task RemoveAsync(StoryImage storyImage);
    }
}
