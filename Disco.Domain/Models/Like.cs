namespace Disco.Domain.Models
{
    public class Like : Base.BaseEntity<int>
    {
        public string UserName { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
