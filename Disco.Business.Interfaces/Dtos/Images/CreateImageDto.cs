using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.Images
{
    public class CreateImageDto
    {
        public IFormFile ImageFile { get; set; }
    }
}
