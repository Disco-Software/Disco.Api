using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dtos.Songs
{
    public class CreateSongDto
    {
        public string Name { get; set; }
        public string ExecutorName { get; set; }
        public IFormFile SongFile { get; set; }
        public IFormFile SongImage { get; set; }
        public int PostId { get; set; }
    }
}
