using Disco.BLL.Models.StoryImages;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IStoryImageService
    {
        Task<StoryImage> CreateStoryImageAsync(CreateStoryImageModel model);
        Task RemoveStoryImageAsync(int id);
    }
}
