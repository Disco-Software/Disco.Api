using Disco.Business.Interfaces.Dtos.PushNotifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.PushNotification.RequestHandlers.CreateInstallation
{
    public class CreateInstallationRequest : IRequest<string>
    {
        public CreateInstallationRequest(DeviceInstallationDto dto)
        {
            Dto = dto;
        }

        public DeviceInstallationDto Dto { get; }
    }
}
