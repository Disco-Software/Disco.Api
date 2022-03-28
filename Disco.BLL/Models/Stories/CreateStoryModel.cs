using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Stories
{
    public class CreateStoryModel
    {
        public List<IFormFile> StoryImages { get; set; }
        public List<IFormFile> StoryVideos { get; set; }

        public int ProfileId { get; set; }
    }
}
