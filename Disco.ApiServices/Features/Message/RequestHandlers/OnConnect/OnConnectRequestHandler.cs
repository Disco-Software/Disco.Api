using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Message.RequestHandlers.OnConnect
{
    public class OnConnectRequestHandler : IRequestHandler<OnConnectRequest>
    {
        private readonly IHubContext<MessageComunicationHub> _hubContext;
        private readonly IAccountService _accountService;
        private readonly IGroupService _groupService;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _contextAccessor;

        public OnConnectRequestHandler(
            IHubContext<MessageComunicationHub> hubContext,
            IAccountService accountService,
            IGroupService groupService,
            IConnectionService connectionService,
            IHttpContextAccessor contextAccessor)
        {
            _hubContext = hubContext;
            _accountService = accountService;
            _groupService = groupService;
            _connectionService = connectionService;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(OnConnectRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var group = await _groupService.GetAsync(int.Parse(_contextAccessor.HttpContext.Request.Query["GroupId"]));

            var account = group.AccountGroups
                .Where(x => x.AccountId == user.AccountId)
                .Select(x => x.Account)
                .FirstOrDefault() ?? throw new ArgumentException();

            var connection = new Connection
            {
                Id = request.ConnectionId,
                UserAgent = _contextAccessor.HttpContext.Request.Headers["User-Agent"],
                IsConnected = true,
            };

            await _connectionService.CreateAsync(connection, account);
            await _hubContext.Groups.AddToGroupAsync(request.ConnectionId, group.Name);
        }
    }
}
