using AutoMapper;
using Disco.Business.Interfaces.Dtos.Group.User.CreateGroup;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.CreateGroup
{
    public class CreateGroupRequestHandler : IRequestHandler<CreateGroupRequest, CreateGroupResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IGroupService _groupService;
        private readonly IAccountGroupService _accountGroupService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CreateGroupRequestHandler(
            IAccountService accountService, 
            IGroupService groupService, 
            IAccountGroupService accountGroupService, 
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _groupService = groupService;
            _accountGroupService = accountGroupService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<CreateGroupResponseDto> Handle(CreateGroupRequest request, CancellationToken cancellationToken)
        {
            var accounts = new List<AccountDto>();

            var currentUser = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var user = await _accountService.GetByIdAsync(request.Dto.UserId);

            var group = await _groupService.CreateAsync();

            var currentUserAccountGroup = await _accountGroupService.CreateAsync(currentUser.Account, group);
            var userAccountGroup = await _accountGroupService.CreateAsync(user.Account, group);

            foreach (var accountGroup in group.AccountGroups)
            {
                var userDto = _mapper.Map<UserDto>(accountGroup.Account.User);
                var accountDto = _mapper.Map<AccountDto>(accountGroup.Account);

                accountDto.User = userDto;

                accounts.Add(accountDto);
            }
            
            var createGroupResponseDto = _mapper.Map<CreateGroupResponseDto>(accounts.AsEnumerable());
            createGroupResponseDto.Id = group.Id;

            return createGroupResponseDto;
        }
    }
}
