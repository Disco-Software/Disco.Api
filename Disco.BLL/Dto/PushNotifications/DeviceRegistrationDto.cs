using Microsoft.Azure.NotificationHubs;

using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dto.PushNotifications
{
    public class DeviceRegistrationDto
    {
        public string InstallationId { get; set; }
        public NotificationPlatform? Platform { get; set; }
        public string PlatformDeviceId { get; set; }
    }
}
