using Disco.Domain.Models.Base;

namespace Disco.Domain.Models
{
    public class UserFollower : BaseModel<int>
    {
        public int UserAccountId { get; set; }
        public Account UserAccount { get; set; }
        
        public int FollowerId { get; set; }
        public Account AccountFollower { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsFriend { get; set; }
    }
}
