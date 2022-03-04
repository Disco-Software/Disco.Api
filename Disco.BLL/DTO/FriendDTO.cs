using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.DTO
{
    public class FriendDTO
    {
        public Profile UserProfile { get; set; }
        public Profile FriendProfile { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
