namespace Disco.Business.Interfaces.Dtos.PostSong.User.GetPostSongs
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
