namespace Disco.Tests.Models
{
    public class PostVideo
    {
        public string VideoSource { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}