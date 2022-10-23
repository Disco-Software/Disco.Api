using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dtos.Songs
{
    public class CreateSongDto
    {
        public string Name { get; set; }
        public string ExecutorName { get; set; }
        public IFormFile Song { get; set; }
        public IFormFile Image { get; set; }
        public Post Post { get; set; }
    }
}
