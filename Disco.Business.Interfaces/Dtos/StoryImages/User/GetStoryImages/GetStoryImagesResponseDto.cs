namespace Disco.Business.Interfaces.Dtos.StoryImages.User.GetAllStoryImages
{
    public class GetStoryImagesResponseDto
    {
        public GetStoryImagesResponseDto() { }
        public GetStoryImagesResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source { get; set; }
    }
}
