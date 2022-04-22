using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.BLL.Models.Songs;
using Disco.DAL.Entities;

namespace Disco.BLL.Interfaces
{
    public interface ISongService
    {
        public Task<PostSong> CreatePostSongAsync(CreateSongModel model);
        public Task Remove(int songId);
    }
}
