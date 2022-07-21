using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dtos.StoryImages
{
    public class CreateStoryImageDto
    {
       public IFormFile StoryImageFile { get; set; }
       public int StoryId { get; set;}
    }
}
