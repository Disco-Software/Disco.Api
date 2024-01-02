using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Interfaces.Options;
using Disco.Business.Interfaces.Options.EmailConfirmation;
using Disco.Business.Services.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ConfirmEmail
{
    public class ConfirmEmailRequestHandler : IRequestHandler<ConfirmEmailRequest>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IEmailGeneratorService _emailGeneratorService;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IOptions<EmailConfirmationCodeConfigurationOptions> _emailConfirmationOptions;

        public ConfirmEmailRequestHandler(
            IAccountService accountService,
            IAccountDetailsService accountDetailsService,
            IEmailGeneratorService emailGeneratorService,
            IEmailSenderService emailSenderService,
            IHttpContextAccessor contextAccessor,
            IOptions<EmailConfirmationCodeConfigurationOptions> emailConfirmationOptions)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _emailSenderService = emailSenderService;
            _emailGeneratorService = emailGeneratorService;
            _contextAccessor = contextAccessor;
            _emailConfirmationOptions = emailConfirmationOptions;
        }

        public async Task Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Email);
            
            if (user == null)
            {
                return;
            }

            var code = ConfirmationCodeGenerationHelper.GenerateEmailConfirmationCode();

            _contextAccessor.HttpContext.Session.SetString("code", code.ToString());
            _contextAccessor.HttpContext.Session.Set("codeExpired", 
                ByteHelper.ConvertDateTimeToBytes(DateTime.UtcNow.AddMinutes(_emailConfirmationOptions.Value.SecurityOptions.LifeTime)));

            var codeExpiredDate = _contextAccessor.HttpContext.Session.GetString("codeExpired");

            var html = await _emailGeneratorService.GenerateEmailConfirmationContentAsync();

            var htmlContent = html.Replace("[email]", user.Email)
                .Replace("[code]", code.ToString());

            var message = MimeMessageHelper.GenerateMimeMessage("E-mail confirmation", htmlContent, request.Email);

            await _emailSenderService.SendOneAsync(message);
        }
    }
}
