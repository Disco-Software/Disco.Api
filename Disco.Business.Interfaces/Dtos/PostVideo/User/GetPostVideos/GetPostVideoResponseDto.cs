namespace Disco.Business.Interfaces.Dtos.PostVideo.User.GetPostVideos
{
    public class GetPostVideoResponseDto
    {
        public GetPostVideoResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source {  get; set; }
    }
}
