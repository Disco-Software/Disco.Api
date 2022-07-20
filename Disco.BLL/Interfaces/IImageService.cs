using Disco.Business.Dto.Images;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IImageService
    {
        Task<PostImage> CreatePostImage(CreateImageDto model);
        Task RemoveImage(int id);
    }
}
