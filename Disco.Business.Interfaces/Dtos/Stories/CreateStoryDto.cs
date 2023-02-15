using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Disco.Business.Interfaces.Dtos.Stories
{
    public class CreateStoryDto
    {
        public List<IFormFile> StoryImages { get; set; }
        public List<IFormFile> StoryVideos { get; set; }

        public int ProfileId { get; set; }
    }
}
