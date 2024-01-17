using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.SearchAccountNames
{
    public class SearchAccountNamesRequestHandler : IRequestHandler<SearchAccountNamesRequest, IEnumerable<string>>
    {
        private readonly IAccountDetailsService _accountDetailsService;

        public SearchAccountNamesRequestHandler(
            IAccountDetailsService accountDetailsService)
        {
            _accountDetailsService = accountDetailsService;
        }

        public async Task<IEnumerable<string>> Handle(SearchAccountNamesRequest request, CancellationToken cancellationToken)
        {
            var searchedNames = await _accountDetailsService.GetAccountsUserNamesSearchResultsAsync(request.Search);

            return searchedNames;
        }
    }
}
