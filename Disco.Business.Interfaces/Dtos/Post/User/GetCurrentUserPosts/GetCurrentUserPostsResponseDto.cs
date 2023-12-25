using Disco.Business.Interfaces.Dtos.Images.User.GetCurrentUserPostImages;
using Disco.Business.Interfaces.Dtos.PostSong.User.GetCurrentUserPostSong;
using Disco.Business.Interfaces.Dtos.PostVideo.User.GetCurrentUserPostVideos;

namespace Disco.Business.Interfaces.Dtos.Post.User.GetCurrentUserPosts
{
    public class GetCurrentUserPostsResponseDto
    {
        public GetCurrentUserPostsResponseDto() { }
        public GetCurrentUserPostsResponseDto(
            int id,
            string description,
            int likes,
            int comments,
            AccountDto author,
            IEnumerable<GetCurrentUserPostImageResponseDto> postImages,
            IEnumerable<GetCurrentUserPostSongResponseDto> postSongs,
            IEnumerable<GetCurrentUserPostVideoResponseDto> postVideos)
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
        
        public int Likes {  get; set; }
        public int Comments { get; set; }

        public DateTime CreatedDate { get; set; }

        public AccountDto Author { get; set; }

        public IEnumerable<GetCurrentUserPostImageResponseDto> PostImages { get; set; }
        public IEnumerable<GetCurrentUserPostSongResponseDto> PostSongs { get; set; }
        public IEnumerable<GetCurrentUserPostVideoResponseDto> PostVideos { get; set; }
    }
}
