using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Services.Helpers;
using Disco.Business.Utils.Constants;
using Disco.Business.Utils.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.RecoveryPasswordCodeChecking
{
    public class RecoveryPasswordCodeCheckingRequestHandler : IRequestHandler<RecoveryPasswordCodeCheckingRequest, bool>
    {
        private readonly IAccountService _accountService;
        private readonly IMemoryCache _memoryCache;

        public RecoveryPasswordCodeCheckingRequestHandler(
            IAccountService accountService,
            IMemoryCache memoryCache)
        {
            _accountService = accountService;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(RecoveryPasswordCodeCheckingRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Email);

            var code = _memoryCache.Get<int>(RecoveryPasswordSessionTypes.RECOVERY_PASSWORD_CODE);
            var codeExpiredString = _memoryCache.Get<string>(RecoveryPasswordSessionTypes.RECOVERY_PASSWORD_CODE_EXPIRED);

            var codeExpired = JsonConvert.DeserializeObject<DateTime>(codeExpiredString);

            if (DateTime.UtcNow > codeExpired)
            {
                _memoryCache.Remove(RecoveryPasswordSessionTypes.RECOVERY_PASSWORD_CODE);
                _memoryCache.Remove(RecoveryPasswordSessionTypes.RECOVERY_PASSWORD_CODE_EXPIRED);
            }

            if(request.Code != code)
            {
                throw new PasswordRecoveryException(new Dictionary<string, string>
                {
                    { "code", "Code was expired" }
                });
            }

            return true;
        }
    }
}
