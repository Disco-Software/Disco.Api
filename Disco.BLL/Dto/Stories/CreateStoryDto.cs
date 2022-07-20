using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Dto.Stories
{
    public class CreateStoryDto
    {
        public List<IFormFile> StoryImages { get; set; }
        public List<IFormFile> StoryVideos { get; set; }

        public int ProfileId { get; set; }
    }
}
