namespace Disco.Business.Interfaces.Dtos.PostVideo.User.CreatePostVideo
{
    public class CreatePostVideoResponseDto
    {
        public CreatePostVideoResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source {  get; set; }
    }
}
