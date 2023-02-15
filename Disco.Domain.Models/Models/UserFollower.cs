using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class UserFollower : BaseModel<int>
    {
        public int FollowingAccountId { get; set; }
        public Account FollowingAccount { get; set; }
        
        public int FollowerAccountId { get; set; }
        public Account FollowerAccount { get; set; }
        public bool IsFollowing { get; set; }
    }
}
