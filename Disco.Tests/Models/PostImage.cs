namespace Disco.Tests.Models
{
    public class PostImage
    {
        public string Source { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}