using Disco.Business.Dto.StoryImages;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IStoryImageService
    {
        Task<StoryImage> CreateStoryImageAsync(CreateStoryImageDto model);
        Task RemoveStoryImageAsync(int id);
    }
}
