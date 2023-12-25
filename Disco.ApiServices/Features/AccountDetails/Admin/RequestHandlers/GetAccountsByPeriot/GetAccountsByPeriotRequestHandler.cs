using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccountsByPeriot;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot
{
    public class GetAccountsByPeriotRequestHandler : IRequestHandler<GetAccountsByPeriotRequest, List<GetAccountsByPeriotResponseDto>>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public GetAccountsByPeriotRequestHandler(
            IAccountService accountService,
            IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<List<GetAccountsByPeriotResponseDto>> Handle(GetAccountsByPeriotRequest request, CancellationToken cancellationToken)
        {
            var users = _accountService.GetUsersByPeriotAsync(request.Periot).Result.ToList();
            var getAccountsByPeriotResponseDtos = new List<GetAccountsByPeriotResponseDto>();

            foreach (var user in users)
            {
                var accountDto = _mapper.Map<AccountDto>(user.Account);
                var userDto = _mapper.Map<UserDto>(user);

                userDto.Account = accountDto;

                var getAccountPeriotResponseDto = _mapper.Map<GetAccountsByPeriotResponseDto>(userDto);

                getAccountsByPeriotResponseDtos.Add(getAccountPeriotResponseDto);
            }

            return getAccountsByPeriotResponseDtos;
        }
    }
}
