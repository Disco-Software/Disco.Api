using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.DeleteMesssageForSender
{
    public class DeleteForSenderRequestHandler : IRequestHandler<DeleteForSenderRequest>
    {
        private readonly ITicketMessageService _ticketMessageService;

        public DeleteForSenderRequestHandler(
            ITicketMessageService ticketMessageService)
        {
            _ticketMessageService = ticketMessageService;
        }

        public async Task Handle(DeleteForSenderRequest request, CancellationToken cancellationToken)
        {
            var message = await _ticketMessageService.GetAsync(request.TicketMessageId);

            await _ticketMessageService.DeleteForSenderAsync(message);
        }
    }
}
