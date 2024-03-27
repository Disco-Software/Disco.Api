using Disco.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disco.Domain.Models.Models
{
    public class TicketMessage : BaseModel<int>
    {
        public string Description {  get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        public int AccountId {  get; set; }
        public Account Account { get; set; }

        public int TicketId {  get; set; }
        public Ticket Ticket { get; set; }
    }
}
