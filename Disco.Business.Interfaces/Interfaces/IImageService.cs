using Disco.Business.Interfaces.Dtos.Images;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IImageService
    {
        Task<PostImage> CreatePostImage(CreateImageDto model);
        Task RemoveImage(int id);
    }
}
