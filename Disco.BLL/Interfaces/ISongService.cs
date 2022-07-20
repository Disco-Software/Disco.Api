using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.BLL.Dto.Songs;
using Disco.DAL.Models;

namespace Disco.BLL.Interfaces
{
    public interface ISongService
    {
        public Task<PostSong> CreatePostSongAsync(CreateSongDto model);
        public Task Remove(int songId);
    }
}
