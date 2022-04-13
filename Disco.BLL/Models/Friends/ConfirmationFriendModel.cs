using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Friends
{
    public class ConfirmationFriendModel
    {
        public int FriendId { get; set; }
        public int FriendProfileId { get; set; }
        public bool IsConfirmed { get; set; }
        public string InstalationId { get; set; }
    }
}
