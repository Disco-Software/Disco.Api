using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Songs
{
    public class CreateSongModel
    {
        public string Name { get; set; }
        public string ExecutorName { get; set; }
        public IFormFile SongFile { get; set; }
        public IFormFile SongImage { get; set; }
        public int PostId { get; set; }
    }
}
