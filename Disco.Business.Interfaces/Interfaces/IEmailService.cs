using Disco.Business.Interfaces.Dtos.EmailNotifications.Admin.AdminEmailNotification;
using Disco.Business.Interfaces.Dtos.EmailNotifications.User.EmailConfirmation;
using MimeKit;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IEmailService
    {
        Task SendOneAsync(MimeMessage message);
        Task SendManyAsync(MimeMessage message, IEnumerable<string> emails);
    }
}
