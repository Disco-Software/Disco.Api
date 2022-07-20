using Disco.BLL.Dto;
using Disco.BLL.Dto.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IRegisterDeviceService
    {
        Task<DeviceRegistrationDto> RegisterDevice(DeviceRegistrationDto model);
        Task<Installation> GetInstallation(DeviceRegistrationDto model);
    }
}
