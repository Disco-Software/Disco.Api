using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.PostVideo.User.CreatePostVideo
{
    public class CreatePostVideoRequestDto
    {
        public CreatePostVideoRequestDto(
            IFormFile videoFile,
            int postId)
        {
            VideoFile = videoFile;
            PostId = postId;
        }

        public IFormFile VideoFile { get; set; }
        public int PostId { get; set; }
    }
}
