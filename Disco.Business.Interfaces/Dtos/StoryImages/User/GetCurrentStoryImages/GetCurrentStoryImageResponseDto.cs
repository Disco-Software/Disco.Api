namespace Disco.Business.Interfaces.Dtos.StoryImages.User.GetCurrentStoryImages
{
    public class GetCurrentStoryImageResponseDto
    {
        public GetCurrentStoryImageResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source { get; set; }
    }
}
