﻿using Disco.Business.Interfaces.Dtos.EmailNotifications.Admin.AdminEmailNotification;
using Disco.Business.Interfaces.Dtos.EmailNotifications.User.EmailConfirmation;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Interfaces.Options;
using Disco.Business.Utils.Guards;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;

namespace Disco.Business.Services.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IOptions<EmailOptions> _emailOptions;
        private readonly ISmtpClient _smtpClient;

        public EmailSenderService(
            IOptions<EmailOptions> emailOptions,
            ISmtpClient smtpClient)
        {
            _emailOptions = emailOptions;
            _smtpClient = smtpClient;

            DefaultGuard.ArgumentNull(_emailOptions);
            DefaultGuard.ArgumentNull(_smtpClient);
        }

        public async Task SendManyAsync(MimeMessage message, IEnumerable<string> emails)
        {
            message.From.Add(new MailboxAddress(_emailOptions.Value.Name, _emailOptions.Value.Mail));

            foreach (var email in emails)
                message.To.Add(new MailboxAddress(_emailOptions.Value.Name, email));

            await _smtpClient.ConnectAsync(_emailOptions.Value.Host, _emailOptions.Value.Port);

            await _smtpClient.AuthenticateAsync(_emailOptions.Value.Name, _emailOptions.Value.Password);

            await _smtpClient.SendAsync(message);
        }

        public async Task SendOneAsync(MimeMessage message)
        {
            message.From.Add(new MailboxAddress(_emailOptions.Value.Name, _emailOptions.Value.Mail));

            await _smtpClient.ConnectAsync(_emailOptions.Value.Host, _emailOptions.Value.Port);

            await _smtpClient.AuthenticateAsync(_emailOptions.Value.Name, _emailOptions.Value.Password);

            await _smtpClient.SendAsync(message);

            await _smtpClient.DisconnectAsync(true);
        }
    }
}
