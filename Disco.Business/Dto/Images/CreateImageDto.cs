using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dto.Images
{
    public class CreateImageDto
    {
        public IFormFile ImageFile { get; set; }
    }
}
