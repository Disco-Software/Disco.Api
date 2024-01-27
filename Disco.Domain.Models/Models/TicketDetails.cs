using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class TicketDetails : BaseModel<int>
    {
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}
