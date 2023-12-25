using Disco.Business.Interfaces.Dtos.EmailNotifications.User.EmailConfirmation;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IEmailService
    {
         Task EmailConfirmationAsync(EmailConfirmationRequestDto model);
    }
}
