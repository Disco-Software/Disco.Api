using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Services.Helpers;
using Disco.Business.Utils.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.RecoveryPasswordCodeChecking
{
    public class RecoveryPasswordCodeCheckingRequestHandler : IRequestHandler<RecoveryPasswordCodeCheckingRequest, bool>
    {
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _contextAccessor;

        public RecoveryPasswordCodeCheckingRequestHandler(
            IAccountService accountService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> Handle(RecoveryPasswordCodeCheckingRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Email);

            var code = _contextAccessor.HttpContext.Session.GetString("passwordRecoveryCode");
            var codeExpiredBytes = _contextAccessor.HttpContext.Session.Get("passwordRecoveryCodeExpired");

            var codeExpired = ByteHepler.ConvertBytesToDateTime(codeExpiredBytes);

            if (DateTime.UtcNow > codeExpired)
            {
                _contextAccessor.HttpContext.Session.Remove("passwordRecoveryCode");
                _contextAccessor.HttpContext.Session.Remove("passwordRecoveryCodeExpired");

                throw new PasswordRecoveryException(new Dictionary<string, string>
                {
                    { "code", "Code was expired" }
                });
            }

            return true;
        }
    }
}
