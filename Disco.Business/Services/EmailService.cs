using Disco.Business.Configurations;
using Disco.Business.Interfaces;
using Disco.Business.Dto.EmailNotifications;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Disco.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailOptions> emailOptions;
        public EmailService(IOptions<EmailOptions> _emailOptions)
        {
            emailOptions = _emailOptions;
        }

        public void EmailConfirmation(EmailConfirmationDto model)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailOptions.Value.Mail, "Disco");
            mailMessage.To.Add(model.ToEmail);
            mailMessage.Subject = model.MessageHeader;
            mailMessage.Body = model.MessageBody;
            mailMessage.IsBodyHtml = model.IsHtmlTemplate;

            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(emailOptions.Value.Mail, emailOptions.Value.Password),
                EnableSsl = true,
            };

            smtpClient.Send(mailMessage);
        }
    }
}
