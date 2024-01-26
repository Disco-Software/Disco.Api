using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class TicketMessage : BaseModel<int>
    {
        public string Description {  get; set; }
        
        public int AccountId {  get; set; }
        public Account Account { get; set; }

        public int TicketId {  get; set; }
        public Ticket Ticket { get; set; }
    }
}
