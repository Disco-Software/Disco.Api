using Disco.BLL.Models;
using Disco.BLL.Models.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IRegisterDeviceService
    {
        Task<DeviceRegistrationModel> RegisterDevice(DeviceRegistrationModel model);
        Task<Installation> GetInstallation(DeviceRegistrationModel model);
    }
}
