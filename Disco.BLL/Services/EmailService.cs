using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailOptions> emailOptions;

        public EmailService(IOptions<EmailOptions> _emailOptions) =>
            emailOptions = _emailOptions;

        public void EmailConfirmation(EmailConfirmationModel model)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            mailMessage.IsBodyHtml = model.IsHtmlTemplate;
            mailMessage.From = new MailAddress(emailOptions.Value.Mail);
            mailMessage.To.Add(new MailAddress(model.ToEmail));
            mailMessage.Subject = model.MessageHeader;
            mailMessage.Body = model.MessageBody;

            smtpClient.Send(mailMessage);
        }
    }
}
