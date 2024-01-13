using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsSearchResultsCount
{
    public class GetAccountsSearchResultsCountRequestHandler : IRequestHandler<GetAccountsSearchResultsCountRequest, int>
    {
        private readonly IAccountDetailsService _accountDetailsService;

        public GetAccountsSearchResultsCountRequestHandler(
            IAccountDetailsService accountDetailsService)
        {
            _accountDetailsService = accountDetailsService;
        }

        public Task<int> Handle(GetAccountsSearchResultsCountRequest request, CancellationToken cancellationToken)
        {
            var getAccountsSearchResultsCount = _accountDetailsService.GetAccountsSearchResultCount(request.Search);

            return Task.FromResult(getAccountsSearchResultsCount);
        }
    }
}
