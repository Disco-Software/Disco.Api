using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class TicketPriority : BaseModel<int>
    {
        public string Name {  get; set; }
        public int Priority { get; set; }
    }
}
