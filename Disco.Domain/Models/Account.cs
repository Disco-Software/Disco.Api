using Disco.Domain.Models.Base;
using System.Collections.Generic;

namespace Disco.Domain.Models
{
    public class Account : BaseModel<int>
    {
        public AccountStatus AccountStatus { get; set; }
        public string Cread { get; set; } = string.Empty;
        public string Photo { get; set; }
        public List<AccountGroup> AccountGroups { get; set; }
        public List<Connection> Connections { get; set; }
        public List<Message> Messages { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<UserFollower> Followers { get; set; } = new List<UserFollower>();
        public List<UserFollower> Following { get; set; } = new List<UserFollower>();
        public List<Story> Stories { get; set; } = new List<Story>();

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
