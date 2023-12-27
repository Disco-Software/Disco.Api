using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.SearchAccountEmails
{
    public class SearchAccountEmailsRequestHandler : IRequestHandler<SearchAccountEmailsRequest, IEnumerable<string>>
    {
        private readonly IAccountDetailsService _accountDetailsService;

        public SearchAccountEmailsRequestHandler(
            IAccountDetailsService accountDetailsService)
        {
            _accountDetailsService = accountDetailsService;
        }

        public async Task<IEnumerable<string>> Handle(SearchAccountEmailsRequest request, CancellationToken cancellationToken)
        {
            var emails = await _accountDetailsService.GetEmailsBySearchAsync(request.Search);

            return emails;
        }
    }
}
