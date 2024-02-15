using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.UpdateTicketStatus
{
    public class UpdateTicketStatusRequest : IRequest<string>
    {
        public UpdateTicketStatusRequest(
            string status, 
            int ticketId)
        {
            Status = status;
            TicketId = ticketId;
        }

        public string Status { get; }
        public int TicketId { get; }
    }
}
