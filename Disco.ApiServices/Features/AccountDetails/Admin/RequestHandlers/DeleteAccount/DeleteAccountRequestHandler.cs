using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Services.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccount
{
    public class DeleteAccountRequestHandler : IRequestHandler<DeleteAccountRequest>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;

        public DeleteAccountRequestHandler(IAccountService accountService, IAccountDetailsService accountDetailsService)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
        }

        public async Task Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByIdAsync(request.Id);
            
            if (user == null)
            {
                throw new ResourceNotFoundException(new Dictionary<string, string>
                {
                    {"id", "id not found" }
                });
            }

            await _accountDetailsService.RemoveAsync(user.Account);
            await _accountService.RemoveAsync(user);
        }
    }
}
