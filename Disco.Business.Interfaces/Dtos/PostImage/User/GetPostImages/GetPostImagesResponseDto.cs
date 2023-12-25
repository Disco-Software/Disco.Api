namespace Disco.Business.Interfaces.Dtos.Images.User.GetPostImages
{
    public class GetPostImagesResponseDto
    {
        public GetPostImagesResponseDto(
            string source)
        {
            Source = source;
        }

        public string Source {  get; set; }
    }
}
