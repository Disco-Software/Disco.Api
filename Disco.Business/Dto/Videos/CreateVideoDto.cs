using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dto.Videos
{
    public class CreateVideoDto
    {
        public IFormFile VideoFile { get; set; }
        public int PostId { get; set; }
    }
}
