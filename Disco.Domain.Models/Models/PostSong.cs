namespace Disco.Domain.Models.Models
{
    public class PostSong : Base.BaseModel<int>
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public string Source { get; set; }
        
        public string ExecutorName { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
