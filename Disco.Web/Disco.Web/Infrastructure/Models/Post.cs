namespace Disco.Web.Infrastructure.Models
{
    public class Post
    {
        public string Description { get; set; }
        public List<object> PostImages { get; set; }
        public List<object> PostSongs { get; set; }
        public List<object> PostVideos { get; set; }
        public List<object> Likes { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int ProfileId { get; set; }
        public int Id { get; set; }

    }
}
