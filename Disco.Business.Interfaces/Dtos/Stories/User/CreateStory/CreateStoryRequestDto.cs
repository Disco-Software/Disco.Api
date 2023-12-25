using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.Stories.User.CreateStory
{
    public class CreateStoryRequestDto
    {
        public CreateStoryRequestDto() { }
        public CreateStoryRequestDto(
            IEnumerable<IFormFile>? storyImages,
            IEnumerable<IFormFile>? storyVideos)
        {
            StoryImages = storyImages;
            StoryVideos = storyVideos;
        }

        public IEnumerable<IFormFile>? StoryImages { get; set; }
        public IEnumerable<IFormFile>? StoryVideos { get; set; }
    }
}
