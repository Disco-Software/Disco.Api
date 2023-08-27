using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.CreateGroup
{
    public class CreateGroupRequestHandler : IRequestHandler<CreateGroupRequest, Domain.Models.Models.Group>
    {
        private readonly IAccountService _accountService;
        private readonly IGroupService _groupService;
        private readonly IAccountGroupService _accountGroupService;
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateGroupRequestHandler(IAccountService accountService, IGroupService groupService, IAccountGroupService accountGroupService, IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _groupService = groupService;
            _accountGroupService = accountGroupService;
            _contextAccessor = contextAccessor;
        }

        public async Task<Domain.Models.Models.Group> Handle(CreateGroupRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var user = await _accountService.GetByIdAsync(request.Dto.UserId);

            var group = await _groupService.CreateAsync();

            var currentUserAccountGroup = await _accountGroupService.CreateAsync(currentUser.Account, group);
            var userAccountGroup = await _accountGroupService.CreateAsync(user.Account, group);

            return group;
        }
    }
}
