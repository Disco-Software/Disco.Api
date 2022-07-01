namespace Disco.Tests.Models
{
    public class Like
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}