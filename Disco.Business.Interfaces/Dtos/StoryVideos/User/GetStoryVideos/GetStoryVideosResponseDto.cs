namespace Disco.Business.Interfaces.Dtos.StoryVideos.User.GetAllStoryVideos
{
    public class GetStoryVideosResponseDto
    {
        public GetStoryVideosResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source { get; set; }
    }
}
