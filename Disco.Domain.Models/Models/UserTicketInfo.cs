using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Models.Models
{
    public class UserTicketInfo : BaseModel<int>
    {
        public TicketDetails Ticket { get; set; }
        public TicketUser User { get; set; }
    }
}
