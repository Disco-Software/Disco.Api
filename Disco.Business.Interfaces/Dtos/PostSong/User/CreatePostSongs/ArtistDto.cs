namespace Disco.Business.Interfaces.Dtos.PostSong.User.CreatePostSong
{
    public class ArtistDto
    {
        public ArtistDto(
            string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
