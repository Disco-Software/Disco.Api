using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class Account : BaseModel<int>
    {
        public AccountStatus AccountStatus { get; set; }
        
        public string Cread { get; set; } = string.Empty;
        public string? Photo { get; set; } = string.Empty;
        public List<AccountGroup> AccountGroups { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Connection> Connections { get; set; } = new List<Connection>();
        public List<Message> Messages { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<UserFollower> Followers { get; set; } = new List<UserFollower>();
        public List<UserFollower> Following { get; set; } = new List<UserFollower>();
        public List<Story> Stories { get; set; } = new List<Story>();
        public List<TicketMessage> TicketMessages { get; set; } = new List<TicketMessage>();
        public List<Ticket> CreatedTickets { get; set; } = new List<Ticket>();
        public List<TicketAccount> TicketAccounts { get; set; } = new List<TicketAccount>();
        public List<PostReating> PostReatings { get; set; } = new List<PostReating>();
        public List<AccountReating> AccountReatings { get; set; } = new List<AccountReating>();
        public List<AccountReating> RecommendedToFollow { get; set; } = new List<AccountReating>();

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
