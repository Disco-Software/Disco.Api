using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.StoryImages
{
    public class CreateStoryImageModel
    {
       public IFormFile StoryImageFile { get; set; }
       public int StoryId { get; set;}
    }
}
