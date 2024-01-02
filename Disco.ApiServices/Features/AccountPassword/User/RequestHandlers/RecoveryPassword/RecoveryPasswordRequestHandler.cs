using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.ResetPassword
{
    public class RecoveryPasswordRequestHandler : IRequestHandler<RecoveryPasswordRequest, string>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;

        public RecoveryPasswordRequestHandler(
            IAccountService accountService, 
            IAccountPasswordService accountPasswordService)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
        }

        public async Task<string> Handle(RecoveryPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);

            await _accountPasswordService.ChengePasswordAsync(user, request.Dto.Password);

            return "";
        }
    }
}
