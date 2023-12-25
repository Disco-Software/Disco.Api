using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.DeleteGroup
{
    public class DeleteGroupRequestHandler : IRequestHandler<DeleteGroupRequest>
    {
        private readonly IAccountService _accountService;
        private readonly IGroupService _groupService;
        private readonly IAccountGroupService _accountGroupService;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteGroupRequestHandler(
            IAccountService accountService,
            IGroupService groupService,
            IAccountGroupService accountGroupService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _groupService = groupService;
            _accountGroupService = accountGroupService;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(DeleteGroupRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var group = await _groupService.GetAsync(request.GroupId);
            var accountGroup = await _accountGroupService.GetAsync(user.AccountId, request.GroupId);

            await _accountGroupService.DeleteAsync(accountGroup);

            await _groupService.DeleteAsync(group);
        }
    }
}
