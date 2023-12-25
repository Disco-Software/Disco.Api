using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.PostSong.User.CreatePostSong
{
    public class CreatePostSongRequestDto
    {
        public CreatePostSongRequestDto() { }
        public CreatePostSongRequestDto(
            string name,
            string executorName,
            IFormFile song,
            IFormFile image,
            Domain.Models.Models.Post post)
        {
            Name = name;
            ExecutorName = executorName;
            Song = song;
            Image = image;
            Post = post;
        }

        public string Name { get; set; }
        public string ExecutorName { get; set; }
        public IFormFile Song { get; set; }
        public IFormFile Image { get; set; }
        public Domain.Models.Models.Post Post { get; set; }
    }
}
