using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot
{
    public class GetAccountsByPeriotRequestHandler : IRequestHandler<GetAccountsByPeriotRequest, List<Domain.Models.Models.User>>
    {
        private readonly IAccountService _accountService;

        public GetAccountsByPeriotRequestHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<List<Domain.Models.Models.User>> Handle(GetAccountsByPeriotRequest request, CancellationToken cancellationToken)
        {
            var users = _accountService.GetUsersByPeriotAsync(request.Periot).Result.ToList();

            return users;
        }
    }
}
