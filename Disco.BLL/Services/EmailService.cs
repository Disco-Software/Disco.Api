using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using MailKit.Net.Smtp;
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

        public EmailService(IOptions<EmailOptions> _emailOptions) =>
            emailOptions = _emailOptions;

        public async Task EmailConfirmation(EmailConfirmationModel model)
        {
            using (var client = new SmtpClient())
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Disco", emailOptions.Value.Mail));
                message.To.Add(new MailboxAddress(model.Name, model.ToEmail));
                message.Subject = model.MessageHeader;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = model.MessageBody };

                try
                {
                    client.Connect(emailOptions.Value.Host, emailOptions.Value.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(emailOptions.Value.Name, emailOptions.Value.Password);

                    await client.SendAsync(message);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                   await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
