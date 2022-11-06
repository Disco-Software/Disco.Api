using Disco.Domain.Models.Base;
using System.Collections.Generic;

namespace Disco.Domain.Models
{
    public class Account : BaseModel<int>
    {
        public AccountStatus Status { get; set; }
        public string Cread { get; set; } = string.Empty;
        public string Photo { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<UserFollower> Followers { get; set; } = new List<UserFollower>();
        public List<UserFollower> Following { get; set; } = new List<UserFollower>();
        public List<Story> Stories { get; set; } = new List<Story>();

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
