using Microsoft.Azure.NotificationHubs;

namespace Disco.Business.Dtos.PushNotifications
{
    public class DeviceRegistrationDto
    {
        public string InstallationId { get; set; }
        public NotificationPlatform? Platform { get; set; }
        public string PlatformDeviceId { get; set; }
    }
}
