using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.Domain.Models.Models
{
    public class Group : BaseModel<int>
    {
        public string Name { get; set; } = Guid.NewGuid().ToString();
        public List<Message> Messages { get; set; }
        public List<AccountGroup> AccountGroups { get; set; }
    }
}
