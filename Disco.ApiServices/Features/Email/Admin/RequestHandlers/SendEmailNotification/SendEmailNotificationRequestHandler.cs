using Disco.Business.Interfaces.Interfaces;
using MediatR;
using MimeKit;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Email.Admin.RequestHandlers.SendEmailNotification
{
    public class SendEmailNotificationRequestHandler : IRequestHandler<SendEmailNotificationRequest>
    {
        private readonly IAccountService _accountService;
        private readonly IEmailSenderService _emailService;

        public SendEmailNotificationRequestHandler(
            IAccountService accountService,
            IEmailSenderService emailService)
        {
            _accountService = accountService;
            _emailService = emailService;
        }

        public async Task Handle(SendEmailNotificationRequest request, CancellationToken cancellationToken)
        {
            var message = new MimeMessage();
            message.Subject = request.AdminEmailNotificatioRequestDto.Title;

            if(request.AdminEmailNotificatioRequestDto.Body.Contains("{{name}}"))
            {
                foreach (var email in request.AdminEmailNotificatioRequestDto.ToEmails)
                {
                    var user = await _accountService.GetByEmailAsync(email);

                    message.To.Add(new MailboxAddress(user.UserName, user.Email));

                    string body = request.AdminEmailNotificatioRequestDto.Body
                        .Replace("{{name}}", user.UserName);

                    BodyBuilder bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = body;

                    message.Body = bodyBuilder.ToMessageBody(); 

                    await _emailService.SendOneAsync(message);
                }
            }
            else
            {
                string body = request.AdminEmailNotificatioRequestDto.Body;

                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = body;

                message.Body = bodyBuilder.ToMessageBody();

                await _emailService.SendManyAsync(message, request.AdminEmailNotificatioRequestDto.ToEmails);
            }

        }
    }
}
