using MimeKit;

namespace Disco.Business.Services.Helpers
{
    public static class MimeMessageGenerationHelper
    {
        public static MimeMessage GeneratePasswordRecoveryEmail(string toEmail,string title, string body)
        {
            MimeMessage message = new MimeMessage();
            message.To.Add(new MailboxAddress("", toEmail));

            message.Subject = title;

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = body;

            message.Body = builder.ToMessageBody();

            return message;
        }
    }
}
