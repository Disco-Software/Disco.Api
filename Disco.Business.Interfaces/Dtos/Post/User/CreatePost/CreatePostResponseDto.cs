using Disco.Business.Interfaces.Dtos.Images.User.CreateImage;
using Disco.Business.Interfaces.Dtos.PostImage.User.CreateImage;
using Disco.Business.Interfaces.Dtos.PostSong.User.CreatePostSong;
using Disco.Business.Interfaces.Dtos.PostVideo.User.CreatePostVideo;

namespace Disco.Business.Interfaces.Dtos.Posts.User.CreatePost
{
    public class CreatePostResponseDto
    {
        public CreatePostResponseDto() { }
        public CreatePostResponseDto(
            string description,
            DateTime createdAt,
            IEnumerable<CreatePostImageResponseDto> postImages,
            IEnumerable<PostSong.User.CreatePostSong.CreatePostSongResponseDto> postSongs,
            IEnumerable<CreatePostVideoResponseDto> postVideos)
        {
            Description = description;
            CreatedAt = createdAt;
            PostImages = postImages;
            PostSongs = postSongs;
            PostVideos = postVideos;
        }

        public string Description {  get; set; }
        public DateTime CreatedAt { get; set; }

        public AccountDto Author { get; set; }

        public IEnumerable<CreatePostImageResponseDto> PostImages { get; set; }
        public IEnumerable<CreatePostSongResponseDto> PostSongs { get; set; }
        public IEnumerable<CreatePostVideoResponseDto> PostVideos { get; set; }
    }
}
