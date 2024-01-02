using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.RecoveryPassword
{
    public class RecoveryPasswordRequestHandler : IRequestHandler<RecoveryPasswordRequest, string>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly IHttpContextAccessor _contextAccessor;

        public RecoveryPasswordRequestHandler(
            IAccountService accountService, 
            IAccountPasswordService accountPasswordService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _contextAccessor = contextAccessor;
        }

        public async Task<string> Handle(RecoveryPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);

            if (request.Dto.IsValidPasswordRecoveryCode == false)
            {
                throw new PasswordRecoveryException(new System.Collections.Generic.Dictionary<string, string>
                {
                    { "code", "Code is invalid" }
                });
            }

            await _accountPasswordService.ChengePasswordAsync(user, request.Dto.Password);

            return "";
        }
    }
}
