using Disco.Business.Interfaces.Dtos.NewsNotification.Admin.SendNewsNotification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.NewsNotification.Admin.RequestHandlers.SendNewsNotification
{
    public class SendNewsNotificationRequest : IRequest
    {
        public SendNewsNotificationRequest(
            SendNewsNotificationRequestDto dto)
        {
            Dto = dto;
        }

        public SendNewsNotificationRequestDto Dto { get; }
    }
}
