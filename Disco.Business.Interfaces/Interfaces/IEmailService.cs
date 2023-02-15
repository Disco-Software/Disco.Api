using Disco.Business.Interfaces.Dtos.EmailNotifications;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IEmailService
    {
         void EmailConfirmation(EmailConfirmationDto model);
    }
}
