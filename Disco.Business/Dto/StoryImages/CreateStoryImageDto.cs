using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dto.StoryImages
{
    public class CreateStoryImageDto
    {
       public IFormFile StoryImageFile { get; set; }
       public int StoryId { get; set;}
    }
}
