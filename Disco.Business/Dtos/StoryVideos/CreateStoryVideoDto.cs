using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dtos.StoryVideos
{
    public class CreateStoryVideoDto
    {
        public IFormFile VideoFile { get; set; }
        public int StoryId { get; set; }
    }
}
