using Disco.Business.Interfaces.Dtos.EmailNotifications.Admin.AdminEmailNotification;
using MediatR;

namespace Disco.ApiServices.Features.Email.Admin.RequestHandlers.SendEmailNotification
{
    public class SendEmailNotificationRequest : IRequest
    {
        public SendEmailNotificationRequest(
            AdminEmailNotificationRequestDto adminEmailNotificationRequestDto)
        {
            AdminEmailNotificatioRequestDto = adminEmailNotificationRequestDto;
        }

        public AdminEmailNotificationRequestDto AdminEmailNotificatioRequestDto { get; }
    }
}
