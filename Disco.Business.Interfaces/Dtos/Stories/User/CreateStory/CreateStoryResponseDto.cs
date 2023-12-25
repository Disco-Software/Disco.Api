using Disco.Business.Interfaces.Dtos.StoryImages.User.CreateStoryImage;
using Disco.Business.Interfaces.Dtos.StoryVideos.User.CreateStoryVideo;

namespace Disco.Business.Interfaces.Dtos.Stories.User.CreateStory
{
    public class CreateStoryResponseDto
    {
        public CreateStoryResponseDto() { }
        public CreateStoryResponseDto(
            IEnumerable<CreateStoryImageResponseDto> storyImages,
            IEnumerable<CreateStoryVideoResponseDto> storyVideos,
            DateTime createdAt,
            AccountDto account)
        {
            StoryImages = storyImages;
            StoryVideos = storyVideos;
            CreatedAt = createdAt;
            Account = account;
        }

        public IEnumerable<CreateStoryImageResponseDto> StoryImages { get; set; }
        public IEnumerable<CreateStoryVideoResponseDto> StoryVideos { get; set; }

        public DateTime CreatedAt { get; set; }

        public AccountDto Account { get; set; }
    }
}
