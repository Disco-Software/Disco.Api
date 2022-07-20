using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dto.StoryImages
{
    public class CreateStoryImageDto
    {
       public IFormFile StoryImageFile { get; set; }
       public int StoryId { get; set;}
    }
}
