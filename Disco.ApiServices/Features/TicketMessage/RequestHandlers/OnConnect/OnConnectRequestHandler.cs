using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.OnConnect
{
    public class OnConnectRequestHandler : IRequestHandler<OnConnectRequest>
    {
        private readonly IHubContext<TicketMessageCommunicationHub> _hubContext;
        private readonly IAccountService _accountService;
        private readonly ITicketService _ticketService;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _contextAccessor;


        public OnConnectRequestHandler(
            IHubContext<TicketMessageCommunicationHub> hubContext,
            IAccountService accountService,
            ITicketService ticketService,
            IConnectionService connectionService,
            IHttpContextAccessor contextAccessor)
        {
            _hubContext = hubContext;
            _accountService = accountService;
            _ticketService = ticketService;
            _connectionService = connectionService;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(OnConnectRequest request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketService.GetAsync(request.TicketName);
            var user = await _accountService.GetByNameAsync(request.UserName);

            var users = ticket.Administrators;

            var account = users
                .Where(x => x.User.UserName == user.UserName)
                .FirstOrDefault();

            if (account == null)
            {
                throw new ArgumentException();
            }

            var context = _contextAccessor.HttpContext;
            var connection = new Connection
            {
                Id = Guid.NewGuid().ToString(),
                IsConnected = true,
                UserAgent = request.UserAgent,
            };

            await _connectionService.CreateAsync(connection, user.Account);

            await _hubContext.Groups.AddToGroupAsync(request.ConnectionId, ticket.Name);
        }
    }
}
