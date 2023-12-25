using Disco.Business.Interfaces.Dtos.StoryImages.User.GetAllStoryImages;
using Disco.Business.Interfaces.Dtos.StoryVideos.User.GetAllStoryVideos;

namespace Disco.Business.Interfaces.Dtos.Stories.User.GetAllStories
{
    public class GetAllStoriesResponseDto
    {
        public GetAllStoriesResponseDto() { }
        public GetAllStoriesResponseDto(
            int id,
            IEnumerable<GetStoryImagesResponseDto> storyImages,
            IEnumerable<GetStoryVideosResponseDto> storyVideos,
            DateTime createdAt,
            AccountDto account)
        {
            Id = id;
            StoryImages = storyImages;
            StoryVideos = storyVideos;
            CreateAt = createdAt;
            Account = account;
        }

        public int Id { get; set; }
        
        public IEnumerable<GetStoryImagesResponseDto> StoryImages { get; set; }
        public IEnumerable<GetStoryVideosResponseDto> StoryVideos { get; set; }

        public DateTime CreateAt { get; set; }

        public AccountDto Account { get; set; }
    }
}
