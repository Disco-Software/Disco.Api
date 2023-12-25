using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.StoryImages.User.CreateStoryImage
{
    public class CreateStoryImageRequestDto
    {
        public CreateStoryImageRequestDto(
            IFormFile storyImage)
        {
            StoryImage = storyImage;
        }

        public IFormFile StoryImage { get; set; }
    }
}
