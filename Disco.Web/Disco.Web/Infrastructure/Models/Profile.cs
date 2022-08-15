namespace Disco.Web.Infrastructure.Models
{
    public class Profile
    {
        public string Status { get; set; }
        public string Cread { get; set; }
        public object Photo { get; set; }
        public List<Post> Posts { get; set; }
        public List<object> Followers { get; set; }
        public List<object> Following { get; set; }
        public List<object> Stories { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }

    }
}
