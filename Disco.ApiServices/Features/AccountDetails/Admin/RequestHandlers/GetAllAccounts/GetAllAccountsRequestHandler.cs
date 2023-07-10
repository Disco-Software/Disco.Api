using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts
{
    internal class GetAllAccountsRequestHandler : IRequestHandler<GetAllAccountsRequest, IEnumerable<Domain.Models.Models.Account>>
    {
        private readonly IAccountDetailsService _accountDetailsService;

        public GetAllAccountsRequestHandler(IAccountDetailsService accountDetailsService)
        {
            _accountDetailsService = accountDetailsService;
        }

        public async Task<IEnumerable<Domain.Models.Models.Account>> Handle(GetAllAccountsRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _accountDetailsService.GetAllAsync(request.PageNumber, request.PageSize);

            return accounts;
        }
    }
}
