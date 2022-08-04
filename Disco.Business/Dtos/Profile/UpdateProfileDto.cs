using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dtos.Profile
{
    public class UpdateProfileDto
    {
        public IFormFile Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string Cread { get; set; }
    }
}
