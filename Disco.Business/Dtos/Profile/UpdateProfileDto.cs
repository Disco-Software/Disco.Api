using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dtos.Profile
{
    public class UpdateAccountDto
    {
        public IFormFile Photo { get; set; }
    }
}
