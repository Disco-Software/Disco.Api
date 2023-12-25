using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.StoryVideos.User.CreateStoryVideo
{
    public class CreateStoryVideoRequestDto
    {
        public CreateStoryVideoRequestDto(
            IFormFile video)
        {
            Video = video;
        }

        public IFormFile Video { get; set; }
    }
}
