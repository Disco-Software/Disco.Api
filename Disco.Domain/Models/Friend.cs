using Disco.Domain.Models.Base;

namespace Disco.Domain.Models
{
    public class Friend : BaseModel<int>
    {
        public int UserProfileId { get; set; }
        public Profile UserProfile { get; set; }
        
        public int FriendProfileId { get; set; }
        public Profile ProfileFriend { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsFriend { get; set; }
    }
}
