using Disco.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Friend : BaseEntity<int>
    {
        public int UserProfileId { get; set; }
        public Profile UserProfile { get; set; }
        
        public int FriendProfileId { get; set; }
        public Profile ProfileFriend { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsFriend { get; set; }
    }
}
