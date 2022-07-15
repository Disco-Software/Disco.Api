using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.EmailNotifications;
using Disco.DAL.EF;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailOptions> emailOptions;
        private readonly ILogger logger;
        public EmailService(IOptions<EmailOptions> _emailOptions, ILogger _logger)
        {
            emailOptions = _emailOptions;
            logger = _logger;
        }

        public void EmailConfirmation(EmailConfirmationModel model)
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
