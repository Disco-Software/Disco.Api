namespace Disco.Business.Interfaces.Dtos.StoryVideos.User.GetCurrentStoryVideos
{
    public class GetCurrentStoryVideosResponseDto
    {
        public GetCurrentStoryVideosResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source {  get; set; }
    }
}
