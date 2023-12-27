using Disco.Business.Interfaces.Dtos.Stories.User.GetAllStories;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        public StoryService(
            IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }
        

        public async Task CreateStoryAsync(Story story)
        {
            story.DateOfCreation = DateTime.UtcNow;
            story.Account.Stories.Add(story);

            await _storyRepository.AddAsync(story);
        }

        public async Task DeleteStoryAsync(int id)
        {
            var story = await _storyRepository.GetAsync(id);

            await _storyRepository.RemoveAsync(story);
        }

        public async Task<Story> GetStoryAsync(int id)
        {
           return await _storyRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Story>> GetAllStoryAsync(User user, GetAllStoriesRequestDto dto)
        {
            var stories = await _storyRepository.GetAllAsync(user.Account!.Id, dto.PageNumber, dto.PageSize);
            
            return stories;
        }

        public int GetStoriesCount(int accountId)
        {
            var storiesCount = _storyRepository.GetStoriesCount(accountId);

            return storiesCount;
        }
    }
}
