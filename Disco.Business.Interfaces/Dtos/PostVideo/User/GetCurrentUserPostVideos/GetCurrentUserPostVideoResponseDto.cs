namespace Disco.Business.Interfaces.Dtos.PostVideo.User.GetCurrentUserPostVideos
{
    public class GetCurrentUserPostVideoResponseDto
    {
        public GetCurrentUserPostVideoResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source {  get; set; }
    }
}
