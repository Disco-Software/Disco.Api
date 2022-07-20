using Disco.BLL.Dto.StoryImages;
using Disco.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IStoryImageService
    {
        Task<StoryImage> CreateStoryImageAsync(CreateStoryImageDto model);
        Task RemoveStoryImageAsync(int id);
    }
}
