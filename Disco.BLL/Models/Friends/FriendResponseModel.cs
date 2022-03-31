using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Friends
{
    public class FriendResponseModel
    {
        public ProfileModel UserProfile { get; set; }
        public ProfileModel FriendProfile { get; set; }
        public int FriendId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
