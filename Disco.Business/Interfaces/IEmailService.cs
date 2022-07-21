using Disco.Business.Dtos.EmailNotifications;

namespace Disco.Business.Interfaces
{
    public interface IEmailService
    {
         void EmailConfirmation(EmailConfirmationDto model);
    }
}
