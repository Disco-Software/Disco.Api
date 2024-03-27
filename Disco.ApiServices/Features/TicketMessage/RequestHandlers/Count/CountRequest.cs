using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.Count
{
    public class CountRequest : IRequest<int>
    {
        public CountRequest(int ticketId)
        {
            TicketId = ticketId;
        }

        public int TicketId { get; }
    }
}
