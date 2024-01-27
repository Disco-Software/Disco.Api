using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Models.Models
{
    public class TicketUser : BaseModel<int>
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string Photo { get; set; }
    }
}
