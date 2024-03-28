using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.GetTicketsCount
{
    public class GetTicketsCountRequestHandler : IRequestHandler<GetTicketsCountRequest, int>
    {
        private readonly ITicketService _ticketService;

        public GetTicketsCountRequestHandler(
            ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public Task<int> Handle(GetTicketsCountRequest request, CancellationToken cancellationToken)
        {
            var count = _ticketService.Count(request.IsArchived);

            return Task.FromResult(count);
        }
    }
}
