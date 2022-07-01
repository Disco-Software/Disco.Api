using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Friends
{
    public class FriendResponseModel
    {
        public DAL.Entities.Profile UserProfile { get; set; }
        public DAL.Entities.Profile FriendProfile { get; set; }
        public int FriendId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
