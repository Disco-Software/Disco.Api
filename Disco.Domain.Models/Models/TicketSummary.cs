using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Models.Models
{
    public class TicketSummary
    {
        public int Id { get; set; }
        public OwnerSummary Owner { get; set; }
        public DateTime CreatedDate {  get; set; }
        public string Priority {  get; set; }
        public string Status {  get; set; }
        public bool IsArchived {  get; set; }
    }
}
