using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class TicketAccount : BaseModel<int>
    {
        public int AccountId {  get; set; }
        public Account Account { get; set; }

        public int TicketId {  get; set; }
        public Ticket Ticket {  get; set; }
    }
}
