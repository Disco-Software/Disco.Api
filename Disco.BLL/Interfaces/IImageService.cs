using Disco.BLL.Models.Images;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IImageService
    {
        Task<PostImage> CreatePostImage(CreateImageModel model);
        Task RemoveImage(int id);
    }
}
