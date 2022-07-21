using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dtos.Images
{
    public class CreateImageDto
    {
        public IFormFile ImageFile { get; set; }
    }
}
