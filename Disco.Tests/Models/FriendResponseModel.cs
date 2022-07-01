﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Tests.Models
{
    public class FriendResponseModel
    {
        public Profile UserProfile { get; set; }
        public Profile FriendProfile { get; set; }
        public int FriendId { get; set; }
        public bool IsConfirmed { get; set; }

    }
}