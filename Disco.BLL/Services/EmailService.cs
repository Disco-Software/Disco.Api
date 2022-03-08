using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.EmailNotifications;
using Disco.DAL.EF;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task EmailConfirmation(EmailConfirmationModel model)
        {
            using (var client = new SmtpClient())
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Disco", emailOptions.Value.Mail));
                message.To.Add(new MailboxAddress(model.Name, model.ToEmail));
                message.Subject = model.MessageHeader;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = model.MessageBody };
                
                client.Connect(emailOptions.Value.Host, emailOptions.Value.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(emailOptions.Value.Name, emailOptions.Value.Password);

                var result = await client.SendAsync(message);
                logger.LogInformation(result);

                client.Disconnect(true);
            }
        }
    }
}
