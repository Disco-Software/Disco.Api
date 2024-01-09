using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Dtos.EmailNotifications.User.EmailConfirmation;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Interfaces.Options.PasswordRecovery;
using Disco.Business.Services.Helpers;
using Disco.Business.Utils.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ForgotPassword
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, string>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly IEmailSenderService _emailService;
        private readonly IPasswordRecoveryGeneratorService _passwordRecoveryGeneratorService;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IOptions<PasswordRecoveryOptions> _passwordRecoveryOptions;
        
        public ForgotPasswordRequestHandler(
            IAccountService accountService, 
            IAccountPasswordService accountPasswordService,
            IEmailSenderService emailService,
            IPasswordRecoveryGeneratorService passwordRecoveryGeneratorService,
            IMemoryCache memoryCache,
            IHttpContextAccessor contextAccessor,
            IOptions<PasswordRecoveryOptions> passwordRecoveryOptions)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _emailService = emailService;
            _passwordRecoveryGeneratorService = passwordRecoveryGeneratorService;
            _contextAccessor = contextAccessor;
            _memoryCache = memoryCache;
            _passwordRecoveryOptions = passwordRecoveryOptions;
        }

        public async Task<string> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);

            var passwordRecoverCode = PasswordRecoveryGenerationCodeHelper.GenerateRecoveryCode();

            var htmlContent = await _passwordRecoveryGeneratorService.GetPasswordRecoveryAsync();

            var code = PasswordRecoveryGenerationCodeHelper.GenerateRecoveryCode();

            _memoryCache.Set(RecoveryPasswordSessionTypes.RECOVERY_PASSWORD_CODE, code);
            _memoryCache.Set(RecoveryPasswordSessionTypes.RECOVERY_PASSWORD_CODE_EXPIRED, 
                JsonConvert.SerializeObject(DateTime.UtcNow.AddMinutes(_passwordRecoveryOptions.Value.LifeTime)));

            var html = htmlContent.Replace("[code]", code.ToString())
                .Replace("[email]", user.Email);

            var message = MimeMessageHelper.GeneratePasswordRecoveryEmail(user.Email, "Password recovery", html);

            await _emailService.SendOneAsync(message);

            return $"Email was sended to your email {user.Email}";
        }
    }
}
