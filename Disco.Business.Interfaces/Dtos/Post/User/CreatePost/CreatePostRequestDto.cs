using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.Posts.User.CreatePost
{
    public class CreatePostRequestDto
    {
        public CreatePostRequestDto() { }
        public CreatePostRequestDto(
            string description,
            List<IFormFile>? postImages,
            List<IFormFile>? postSongs,
            List<string>? postSongNames,
            List<string>? executorNames,
            List<IFormFile>? postVideos)
        {
            Description = description;
            PostImages = postImages;
            PostSongs = postSongs;
            PostSongNames = postSongNames;
            ExecutorNames = executorNames;
            PostVideos = postVideos;
        }

        public string Description { get; set; }
        public List<IFormFile>? PostImages { get; set; }
        public List<IFormFile>? PostSongs { get; set; }
        public List<IFormFile>? PostSongImages { get; set; }
        public List<string>? PostSongNames { get; set; }
        public List<string>? ExecutorNames { get; set; }
        public List<IFormFile>? PostVideos { get; set; }

    }
}
