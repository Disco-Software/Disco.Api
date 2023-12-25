using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.PostImage.User.CreateImage
{
    public class CreatePostImageRequestDto
    {
        public CreatePostImageRequestDto() { }
        public CreatePostImageRequestDto(
            IFormFile imageFile)
        {
            ImageFile = imageFile;
        }

        public IFormFile ImageFile { get; set; }
    }
}
