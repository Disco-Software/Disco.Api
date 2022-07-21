using Disco.Business.Dto.EmailNotifications;

namespace Disco.Business.Interfaces
{
    public interface IEmailService
    {
         void EmailConfirmation(EmailConfirmationDto model);
    }
}
