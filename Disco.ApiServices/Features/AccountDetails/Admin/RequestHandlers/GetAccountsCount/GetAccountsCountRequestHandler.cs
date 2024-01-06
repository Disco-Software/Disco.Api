using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsCount
{
    public class GetAccountsCountRequestHandler : IRequestHandler<GetAccountsCountRequest, int>
    {
        private readonly IAccountDetailsService _accountDetailsService;

        public GetAccountsCountRequestHandler(
            IAccountDetailsService accountDetailsService)
        {
            _accountDetailsService = accountDetailsService;
        }

        public Task<int> Handle(GetAccountsCountRequest request, CancellationToken cancellationToken)
        {
            var accountsCount = _accountDetailsService.GetAccountCount();

            return Task.FromResult(accountsCount);
        }
    }
}
