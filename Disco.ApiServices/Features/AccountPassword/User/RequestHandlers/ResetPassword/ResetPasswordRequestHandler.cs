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
    internal class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, string>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;

        public ResetPasswordRequestHandler(
            IAccountService accountService, 
            IAccountPasswordService accountPasswordService)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
        }

        public async Task<string> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);

            if (user == null)
                throw new ResourceNotFoundException(new Dictionary<string, string> { { "email", "Email is not valid" } });

            await _accountPasswordService.ChengePasswordAsync(user, request.Dto.ConfirmationToken, request.Dto.Password);

            return "Password successfuly reset";

        }
    }
}
