using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.DeleteMessageForAll
{
    public class DeleteMessageForAllRequestHandler : IRequestHandler<DeleteMessageForAllRequest>
    {
        private readonly IAccountService _accountService;
        private readonly ITicketMessageService _ticketMessageService;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteMessageForAllRequestHandler(
            IAccountService accountService,
            ITicketMessageService ticketMessageService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _ticketMessageService = ticketMessageService;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(DeleteMessageForAllRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(request.ClaimsPrincipal);
            var message = await _ticketMessageService.GetAsync(request.Id);

            await _ticketMessageService.DeleteAsync(message);
        }
    }
}
