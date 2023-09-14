using Disco.Business.Interfaces.Options;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.EmailNotifications;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using Disco.Business.Interfaces.Interfaces;

namespace Disco.Business.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailOptions> _emailOptions;
        public EmailService(IOptions<EmailOptions> emailOptions)
        {
            _emailOptions = emailOptions;
        }

        public void EmailConfirmation(EmailConfirmationDto dto)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailOptions.Value.Mail, _emailOptions.Value.Name);
            mailMessage.To.Add(dto.ToEmail);
            mailMessage.Subject = dto.MessageHeader;
            mailMessage.Body = dto.MessageBody;
            mailMessage.IsBodyHtml = dto.IsHtmlTemplate;

            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(_emailOptions.Value.Mail, _emailOptions.Value.Password),
                EnableSsl = true,
            };

            smtpClient.Send(mailMessage);
        }
    }
}
