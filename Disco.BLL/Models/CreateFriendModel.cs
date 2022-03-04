﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models
{
    public class CreateFriendModel
    {
        public int UserId { get; set; }
        public int FriendId { get; set;}
        public bool IsFriend { get; set; }
        public bool IsConfirmed { get; set; }
    }
}