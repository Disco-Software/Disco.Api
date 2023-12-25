using Disco.Business.Interfaces.Dtos.Comment.User.GetAllComments;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Comment.RequestHandlers.OnConnect
{
    public class OnConnectRequestHandler : IRequestHandler<OnConnectRequest>
    {
        private readonly ICommentService _commentService;
        private readonly IAccountService _accountService;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _contextAccessor;

        public OnConnectRequestHandler(
            ICommentService commentService,
            IAccountService accountService,
            IConnectionService connectionService,
            IHttpContextAccessor contextAccessor)
        {
            _commentService = commentService;
            _accountService = accountService;
            _connectionService = connectionService;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(OnConnectRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var connnection = new Connection()
            {
                IsConnected = true,
                Id = Guid.NewGuid().ToString(),
                UserAgent = _contextAccessor.HttpContext.Request.Headers["User-Agent"],
            };

            await _connectionService.CreateAsync(connnection, user.Account); 
        }
    }
}
