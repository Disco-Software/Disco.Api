using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Interfaces.Options.PasswordRecovery;
using Disco.Business.Services.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.ForgotPassword
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, string>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly IPasswordRecoveryGeneratorService _passwordRecoveryGeneratorService;
        private readonly IEmailSenderService _emailService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IOptions<PasswordRecoveryOptions> _passwordRecoveryOptions;

        public ForgotPasswordRequestHandler(
            IAccountService accountService, 
            IAccountPasswordService accountPasswordService,
            IPasswordRecoveryGeneratorService passwordRecoveryService,
            IEmailSenderService emailService,
            IOptions<PasswordRecoveryOptions> _passwordRecoveryOptions,
            IHttpContextAccessor contextAccessor,
            IOptions<PasswordRecoveryOptions> passwordRecoveryOptions)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _passwordRecoveryGeneratorService = passwordRecoveryService;
            _emailService = emailService;
            _contextAccessor = contextAccessor;
            _passwordRecoveryOptions = passwordRecoveryOptions;
        }

        public async Task<string> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);

            var passwordRecoverCode = PasswordRecoveryGenerationCodeHelper.GenerateRecoveryCode();

            var htmlContent = await _passwordRecoveryGeneratorService.GetPasswordRecoveryAsync();

            var code = PasswordRecoveryGenerationCodeHelper.GenerateRecoveryCode();

            _contextAccessor.HttpContext.Session.SetString("passwordRecoveryCode", code.ToString());
            _contextAccessor.HttpContext.Session.Set("passwordRecoveryCodeExpired",
                ByteHepler.ConvertDateTimeToBytes(DateTime.UtcNow.AddMinutes(_passwordRecoveryOptions.Value.LifeTime)));

            var html = htmlContent.Replace("[code]", code.ToString())
                .Replace("[email]", user.Email);

            var message = MimeMessageHelper.GeneratePasswordRecoveryEmail(user.Email, "Password recovery", html);

            await _emailService.SendOneAsync(message);

            return $"Email was submit to your email {user.Email}";
        }
    }
}
