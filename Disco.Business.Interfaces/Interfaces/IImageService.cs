using Disco.Business.Interfaces.Dtos.PostImage.User.CreateImage;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IImageService
    {
        Task<PostImage> CreatePostImage(CreatePostImageRequestDto model);
        Task RemoveImageAsync(int id);
    }
}
