using Disco.BLL.Models.Videos;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IVideoService
    {
        Task<PostVideo> CreateVideoAsync(CreateVideoModel model);
        Task RemoveVideoAsync(int id);
    }
}
