using Disco.Domain.Models.Base;

namespace Disco.Domain.Models
{
    public class Friend : BaseModel<int>
    {
        public int UserProfileId { get; set; }
        public Account UserProfile { get; set; }
        
        public int FriendProfileId { get; set; }
        public Account ProfileFriend { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsFriend { get; set; }
    }
}
