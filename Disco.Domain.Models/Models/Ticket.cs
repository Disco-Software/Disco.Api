using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Models.Models
{
    public class Ticket : BaseModel<int>
    {
        public string Description {  get; set; }

        public bool IsArchived {  get; set; }

        public List<UserTicketInfo> Administrators { get; set; }

        public int OwnerId {  get; set; }
        public Account Owner { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ClosedDate { get; set; }

        public List<TicketMessage> TicketMessages { get; set; }

        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
    }
}
