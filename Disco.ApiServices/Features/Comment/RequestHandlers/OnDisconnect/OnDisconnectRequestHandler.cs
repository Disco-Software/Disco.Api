using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Comment.RequestHandlers.OnDisconnect
{
    public class OnDisconnectRequestHandler : IRequestHandler<OnDisconnectRequest>
    {
        private readonly IAccountService _accountService;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _contextAccessor;

        public OnDisconnectRequestHandler(
            IAccountService accountService,
            IConnectionService connectionService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _connectionService = connectionService;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(OnDisconnectRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var connection = await _connectionService.GetAsync(_contextAccessor.HttpContext.Connection.Id);

            await _connectionService.DeleteAsync(connection, user.Account); ;
        }
    }
}
