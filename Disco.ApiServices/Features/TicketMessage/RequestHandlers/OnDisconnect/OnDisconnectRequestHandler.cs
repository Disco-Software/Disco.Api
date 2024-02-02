using Disco.ApiServices.Features.Message;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.OnDisconnect
{
    public class OnDisconnectRequestHandler : IRequestHandler<OnDisconnectRequest>
    {
        private readonly IHubContext<MessageComunicationHub> _hubContext;
        private readonly IAccountService _accountService;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OnDisconnectRequestHandler(
            IHubContext<MessageComunicationHub> hubContext,
            IAccountService accountService,
            IConnectionService connectionService,
            IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
            _hubContext = hubContext;
            _connectionService = connectionService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(OnDisconnectRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_httpContextAccessor.HttpContext.User);
            var connection = await _connectionService.GetAsync(request.ConnectionId);

            await _connectionService.DeleteAsync(connection, user.Account);

            await _hubContext.Groups.RemoveFromGroupAsync(request.ConnectionId, _httpContextAccessor.HttpContext.Request.Query["GroupName"]);
        }
    }
}
