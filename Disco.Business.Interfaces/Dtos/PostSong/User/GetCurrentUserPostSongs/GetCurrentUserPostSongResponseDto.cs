namespace Disco.Business.Interfaces.Dtos.PostSong.User.GetCurrentUserPostSong
{
    public class GetCurrentUserPostSongResponseDto
    {
        public GetCurrentUserPostSongResponseDto() { }
        public GetCurrentUserPostSongResponseDto(
            int id,
            string name,
            string imageSource,
            string source,
            ArtistDto artist)
        {
            Id = id; 
            Name = name;
            ImageSource = imageSource;
            Source = source;
            Artist = artist;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSource {  get; set; }
        public string Source {  get; set; }
        public ArtistDto Artist { get; set; }
    }
}
