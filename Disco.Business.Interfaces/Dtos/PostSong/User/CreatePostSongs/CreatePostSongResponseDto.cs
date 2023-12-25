namespace Disco.Business.Interfaces.Dtos.PostSong.User.CreatePostSong
{
    public class CreatePostSongResponseDto
    {
        public CreatePostSongResponseDto() { }
        public CreatePostSongResponseDto(
            int id,
            string name,
            string imageUrl,
            string source,
            ArtistDto artist)
        {
            Id = id; 
            Name = name;
            ImageUrl = imageUrl;
            Source = source;
            Artist = artist;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl {  get; set; }
        public string Source {  get; set; }
        public ArtistDto Artist { get; set; }
    }
}
