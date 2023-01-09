using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Domain.Models
{
    public class Group : BaseModel<int>
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Message> Messages { get; set; }
        public List<AccountGroup> AccountGroups { get; set; }
    }
}
