namespace Disco.Business.Interfaces.Dtos.StoryImages.User.CreateStoryImage
{
    public class CreateStoryImageResponseDto
    {
        public CreateStoryImageResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source {  get; set; }
    }
}
