﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Domain.Models
{
    public class AccountStatus : Base.BaseModel<int>
    {
        public string LastStatus { get; set; }
        public int FollowersCount { get; set; }
        public int NextStatusId { get; set; }
        public int UserTarget { get; set; }
    }
}