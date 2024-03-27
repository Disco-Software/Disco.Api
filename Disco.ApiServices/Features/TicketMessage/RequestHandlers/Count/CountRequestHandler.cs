using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.Count
{
    public class CountRequestHandler : IRequestHandler<CountRequest, int>
    {
        private readonly ITicketMessageService _ticketMessageService;

        public CountRequestHandler(
            ITicketMessageService ticketMessageService)
        {
            _ticketMessageService = ticketMessageService;
        }

        public Task<int> Handle(CountRequest request, CancellationToken cancellationToken)
        {
            var count = _ticketMessageService.Count(request.TicketId);

            return Task.FromResult(count);
        }
    }
}
