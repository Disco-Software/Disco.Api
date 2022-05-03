using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.StoryVideos
{
    public class CreateStoryVideoModel
    {
        public IFormFile VideoFile { get; set; }
        public int StoryId { get; set; }
    }
}
