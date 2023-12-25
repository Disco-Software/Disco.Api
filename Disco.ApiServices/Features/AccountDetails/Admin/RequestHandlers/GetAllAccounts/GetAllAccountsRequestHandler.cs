using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAllAccounts;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts
{
    public class GetAllAccountsRequestHandler : IRequestHandler<GetAllAccountsRequest, IEnumerable<GetAllAccountsResponseDto>>
    {
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IMapper _mapper;

        public GetAllAccountsRequestHandler(
            IAccountDetailsService accountDetailsService,
            IMapper mapper)
        {
            _accountDetailsService = accountDetailsService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllAccountsResponseDto>> Handle(GetAllAccountsRequest request, CancellationToken cancellationToken)
        {
            var getAllAcountsResponseDtos = new List<GetAllAccountsResponseDto>();

            var accounts = await _accountDetailsService.GetAllAsync(request.PageNumber, request.PageSize);

            foreach (var account in accounts)
            {
                var userDto = _mapper.Map<UserDto>(account.User);
                var accountDto = _mapper.Map<AccountDto>(account);

                accountDto.User = userDto;

                var getAllAccountsDto = _mapper.Map<GetAllAccountsResponseDto>(accountDto);

                getAllAcountsResponseDtos.Add(getAllAccountsDto);
            }

            return getAllAcountsResponseDtos;
        }
    }
}
