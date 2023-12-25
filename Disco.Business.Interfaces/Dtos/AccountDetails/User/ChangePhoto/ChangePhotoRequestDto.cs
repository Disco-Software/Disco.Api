using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.AccountDetails.User.ChangePhoto
{
    public class ChangePhotoRequestDto
    {
        public ChangePhotoRequestDto(
            IFormFile photo)
        {
            Photo = photo;
        }

        public IFormFile Photo { get; set; }
    }
}
