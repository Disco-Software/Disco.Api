using Disco.Business.Interfaces.Dtos.Stories.User.GetAllStories;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IStoryService
    {
        Task CreateStoryAsync(Story story);
        Task DeleteStoryAsync(int id);
        Task<Story> GetStoryAsync(int id);
        Task<IEnumerable<Story>> GetAllStoryAsync(User user, GetAllStoriesRequestDto model);
        int GetStoryCount(int accountId);
    }
}
