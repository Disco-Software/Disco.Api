using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.StoryVideos
{
    public class CreateStoryVideoDto
    {
        public IFormFile VideoFile { get; set; }
        public int StoryId { get; set; }
    }
}
