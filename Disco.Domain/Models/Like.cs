namespace Disco.Domain.Models
{
    public class Like : Base.BaseModel<int>
    {
        public string UserName { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
