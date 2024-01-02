using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Helpers
{
    public static class MimeMessageHelper
    {
        public static MimeMessage GeneratePasswordRecoveryEmail(string toEmail, string title, string body)
        {
            MimeMessage message = new MimeMessage();
            message.To.Add(new MailboxAddress("", toEmail));

            message.Subject = title;

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = body;

            message.Body = builder.ToMessageBody();

            return message;
        }


        public static MimeMessage GenerateMimeMessage(string title, string body, string toEmail)
        {
            var message = new MimeMessage();
            message.Subject = title;

            message.To.Add(new MailboxAddress(toEmail, toEmail));

            var builder = new BodyBuilder();
            builder.HtmlBody = body;

            message.Body = builder.ToMessageBody();

            return message;
        }
    }
}
