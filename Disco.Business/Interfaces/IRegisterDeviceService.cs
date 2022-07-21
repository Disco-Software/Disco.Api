using Disco.Business.Dtos.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IRegisterDeviceService
    {
        Task<DeviceRegistrationDto> RegisterDevice(DeviceRegistrationDto model);
        Task<Installation> GetInstallation(DeviceRegistrationDto model);
    }
}
