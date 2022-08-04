namespace Disco.Domain.Models
{
    public class PostVideo : Base.BaseModel<int>
    {
        public string VideoSource { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
