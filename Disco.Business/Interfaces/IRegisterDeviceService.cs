using Disco.Business.Dto.PushNotifications;
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
