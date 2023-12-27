using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.SearchAccounts;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.SearchAccounts
{
    public class SearchAccountsRequestHandler : IRequestHandler<SearchAccountsRequest, IEnumerable<SearchAccountsResponseDto>>
    {
        private IAccountDetailsService _accountDetailsService;
        private IMapper _mapper;

        public SearchAccountsRequestHandler(
            IAccountDetailsService accountDetailsService,
            IMapper mapper)
        {
            _accountDetailsService = accountDetailsService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchAccountsResponseDto>> Handle(SearchAccountsRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _accountDetailsService.SearchAsync(request.Search, request.PageNumber, request.PageSize);

            var searchAccountsResponseDtos = _mapper.Map<IEnumerable<SearchAccountsResponseDto>>(accounts);

            return searchAccountsResponseDtos;
        }
    }
}
