namespace Disco.Business.Interfaces.Dtos.Images.User.GetCurrentUserPostImages
{
    public class GetCurrentUserPostImageResponseDto
    {
        public GetCurrentUserPostImageResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source {  get; set; }
    }
}
