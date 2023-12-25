namespace Disco.Business.Interfaces.Dtos.Images.User.CreateImage
{
    public class CreatePostImageResponseDto
    {
        public CreatePostImageResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source {  get; set; }
    }
}
