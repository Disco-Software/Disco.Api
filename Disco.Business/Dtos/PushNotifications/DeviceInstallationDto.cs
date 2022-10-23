using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;

namespace Disco.Business.Dtos.PushNotifications
{
    public class DeviceInstallationDto
    {
        public string InstallationId { get; set; }
        public NotificationPlatform? Platform { get; set; }
        public string PlatformDeviceId { get; set; }
        public string PushChannel { get; set; }
        public IList<string> Tags { get; set; } = Array.Empty<string>();
    }
}
