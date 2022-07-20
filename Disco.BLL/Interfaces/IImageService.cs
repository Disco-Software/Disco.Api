using Disco.BLL.Dto.Images;
using Disco.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IImageService
    {
        Task<PostImage> CreatePostImage(CreateImageDto model);
        Task RemoveImage(int id);
    }
}
