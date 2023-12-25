using Disco.Business.Interfaces.Dtos.StoryImages.User.GetCurrentStoryImages;
using Disco.Business.Interfaces.Dtos.StoryVideos.User.GetCurrentStoryVideos;

namespace Disco.Business.Interfaces.Dtos.Stories.User.GetStory
{
    public class GetStoryResponseDto
    {
        public GetStoryResponseDto() { }
        public GetStoryResponseDto(
            IEnumerable<GetCurrentStoryImageResponseDto> storyImages,
            IEnumerable<GetCurrentStoryVideosResponseDto> storyVideos,
            DateTime createdAt, 
            AccountDto account)
        {
            StoryImages = storyImages;
            StoryVideos = storyVideos;
            CreatedAt = createdAt;
            Account = account;
        }

        public IEnumerable<GetCurrentStoryImageResponseDto> StoryImages { get; set; }
        public IEnumerable<GetCurrentStoryVideosResponseDto> StoryVideos { get; set; }
        public DateTime CreatedAt { get; set; }
        public AccountDto Account { get; set; }
    }
}
