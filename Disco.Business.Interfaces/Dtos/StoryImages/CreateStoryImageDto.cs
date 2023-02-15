using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.StoryImages
{
    public class CreateStoryImageDto
    {
       public IFormFile StoryImageFile { get; set; }
       public int StoryId { get; set;}
    }
}
