using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Friends
{
    public class CreateFriendModel
    {
        public int FriendId { get; set;}
        public bool IsFriend { get; set; }
        public bool IsConfirmed { get; set; }
        public string IntalationId { get; set; }
    }
}
