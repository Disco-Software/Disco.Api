namespace Disco.Business.Interfaces.Dtos.StoryVideos.User.CreateStoryVideo
{
    public class CreateStoryVideoResponseDto
    {
        public CreateStoryVideoResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source { get; set; }
    }
}
