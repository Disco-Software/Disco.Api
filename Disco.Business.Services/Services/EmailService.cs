using Disco.Business.Interfaces.Options;
using Disco.Business.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using Disco.Business.Interfaces.Interfaces;
using MailKit.Net.Smtp;
using System.Net.Mail;
using MimeKit;
using Microsoft.AspNetCore.Html;
using Disco.Business.Interfaces.Dtos.EmailNotifications.User.EmailConfirmation;

namespace Disco.Business.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailOptions> _emailOptions;
        private readonly ISmtpClient _smtpClient;

        public EmailService(
            IOptions<EmailOptions> emailOptions,
            ISmtpClient smtpClient)
        {
            _emailOptions = emailOptions;
            _smtpClient = smtpClient;
        }

        public async Task EmailConfirmationAsync(EmailConfirmationRequestDto dto)
        {
            MimeMessage mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(_emailOptions.Value.Name, _emailOptions.Value.Mail));
            mailMessage.To.Add(new MailboxAddress(dto.Name, dto.ToEmail));
            mailMessage.Subject = dto.MessageHeader;

            HtmlContentBuilder builder = new HtmlContentBuilder();
            builder.Append(dto.MessageBody);

            await _smtpClient.AuthenticateAsync(_emailOptions.Value.Name, _emailOptions.Value.Password);

            await _smtpClient.SendAsync(mailMessage);
        }
    }
}
