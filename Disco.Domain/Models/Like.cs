namespace Disco.Domain.Models
{
    public class Like : Base.BaseModel<int>
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
