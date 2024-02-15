using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.UpdateTicketStatus
{
    public class UpdateTicketStatusRequestHandler : IRequestHandler<UpdateTicketStatusRequest, string>
    {
        private readonly ITicketService _ticketService;

        public UpdateTicketStatusRequestHandler(
            ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<string> Handle(UpdateTicketStatusRequest request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketService.GetAsync(request.TicketId);

            await _ticketService.UpdateTicketStatusAsync(ticket, request.Status);

            return ticket.Status.Name;
        }
    }
}
