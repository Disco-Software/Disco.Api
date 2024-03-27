using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class TicketStatus : BaseModel<int>
    {
        public string Name { get; set; }
        public bool IsArchived { get; set; }
    }
}
