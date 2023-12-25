using Disco.Business.Interfaces.Dtos.Images.User.GetCurrentUserPostImages;
using Disco.Business.Interfaces.Dtos.Images.User.GetPostImages;
using Disco.Business.Interfaces.Dtos.PostSong.User.GetCurrentUserPostSong;
using Disco.Business.Interfaces.Dtos.PostSong.User.GetPostSongs;
using Disco.Business.Interfaces.Dtos.PostVideo.User.GetCurrentUserPostVideos;
using Disco.Business.Interfaces.Dtos.PostVideo.User.GetPostVideos;

namespace Disco.Business.Interfaces.Dtos.Post.User.GetPosts
{
    public class GetPostsResponseDto
    {
        public GetPostsResponseDto() { }
        public GetPostsResponseDto(
            int id,
            string description,
            int likes,
            int comments,
            AccountDto author,
            IEnumerable<GetPostImagesResponseDto> postImages,
            IEnumerable<GetPostSongResponseDto> postSongs,
            IEnumerable<GetPostVideoResponseDto> postVideos)
        {
            Id = id;
            Description = description;
            Likes = likes;
            Comments = comments;
            Author = author;
            PostImages = postImages;
            PostSongs = postSongs;
            PostVideos = postVideos;
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public int Likes { get; set; }
        public int Comments { get; set; }

        public DateTime CreatedDate { get; set; }

        public AccountDto Author { get; set; }

        public IEnumerable<GetPostImagesResponseDto> PostImages { get; set; }
        public IEnumerable<GetPostSongResponseDto> PostSongs { get; set; }
        public IEnumerable<GetPostVideoResponseDto> PostVideos { get; set; }
    }
}
