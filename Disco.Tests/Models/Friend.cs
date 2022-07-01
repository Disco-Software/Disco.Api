namespace Disco.Tests.Models
{
    public class Friend
    {
        public int UserProfileId { get; set; }
        public Profile UserProfile { get; set; }

        public int FriendProfileId { get; set; }
        public Profile ProfileFriend { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsFriend { get; set; }

    }
}