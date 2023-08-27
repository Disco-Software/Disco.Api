using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.ForgotPassword
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, string>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly IEmailService _emailService;

        public ForgotPasswordRequestHandler(IAccountService accountService, IAccountPasswordService accountPasswordService, IEmailService emailService)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _emailService = emailService;
        }

        public async Task<string> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);

            if (user == null)
            {
                throw new ResourceNotFoundException(new Dictionary<string, string>
                {
                    {"email", "Email is not valid" }
                });
            }

            var passwordResetToken = await _accountPasswordService.GetPasswordConfirmationTokenAsync(user);

            _emailService.EmailConfirmation(new Business.Interfaces.Dtos.EmailNotifications.EmailConfirmationDto
            {
                ToEmail = user.Email,
                IsHtmlTemplate = true,
                MessageHeader = "Email confirmation"
            });

            return passwordResetToken;
        }
    }
}
