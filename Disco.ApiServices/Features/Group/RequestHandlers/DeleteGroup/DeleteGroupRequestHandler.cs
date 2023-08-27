using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.DeleteGroup
{
    public class DeleteGroupRequestHandler : IRequestHandler<DeleteGroupRequest>
    {
        private readonly IAccountService _accountService;
        private readonly IGroupService _groupService;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteGroupRequestHandler(IAccountService accountService, IGroupService groupService, IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _groupService = groupService;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(DeleteGroupRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var group = await _groupService.GetAsync(request.GroupId);

            await _groupService.DeleteAsync(group, user.Account);
        }
    }
}
