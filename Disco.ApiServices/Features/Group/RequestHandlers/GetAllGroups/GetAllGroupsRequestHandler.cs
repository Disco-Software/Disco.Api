using AutoMapper;
using Disco.Business.Interfaces.Dtos.Group.User.GetAllGroups;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.GetAll
{
    public class GetAllGroupsRequestHandler : IRequestHandler<GetAllGroupsRequest, IEnumerable<GetAllGroupsResponseDto>>
    {
        private readonly IAccountService _accountService;
        private readonly IGroupService _groupService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetAllGroupsRequestHandler(
            IAccountService accountService, 
            IGroupService groupService, 
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _groupService = groupService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllGroupsResponseDto>> Handle(GetAllGroupsRequest request, CancellationToken cancellationToken)
        {
            var groupDtos = new List<GetAllGroupsResponseDto>();
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var groups = await _groupService.GetAllAsync(user.Id, request.PageNumber, request.PageSize);

            foreach (var group in groups)
            {
                var accountDtos = new List<AccountDto>();

                foreach (var accountGroup in group.AccountGroups)
                {
                    var userDto = _mapper.Map<UserDto>(accountGroup.Account.User);
                    var accountDto = _mapper.Map<AccountDto>(accountGroup.Account);

                    accountDto.User = userDto;

                    accountDtos.Add(accountDto);
                }

                var getAllGroupsResponseDto = _mapper.Map<GetAllGroupsResponseDto>(group);
                getAllGroupsResponseDto.Accounts = accountDtos;

                groupDtos.Add(getAllGroupsResponseDto);
            }

            return groupDtos;
        }
    }
}
