using Disco.Business.Interfaces.Dtos.PushNotifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.PushNotification.RequestHandlers.SubmitNotification
{
    public class SubmitNotificationRequest : IRequest<string>
    {
        public SubmitNotificationRequest(PushNotificationBaseDto dto)
        {
            Dto = dto;
        }

        public PushNotificationBaseDto Dto { get; }
    }
}
