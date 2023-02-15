using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Domain.Models.Models
{
    public class AccountGroup : BaseModel<int>
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
