using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.Domain.Models.Models
{
    public class AccountStatus : BaseModel<int>
    {
        public string LastStatus { get; set; }
        public int FollowersCount { get; set; }
        public int NextStatusId { get; set; }
        public int UserTarget { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
