using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;

namespace Disco.Business.Interfaces.Dtos.PushNotifications
{
    public class DeviceInstallationDto
    {
        public DeviceInstallationDto(
            string installationId,
            NotificationPlatform platform,
            string platformDeviceId)
        {
            InstallationId = installationId;
            Platform = platform;
            PlatformDeviceId = platformDeviceId;
        }

        public string InstallationId { get; set; }
        public NotificationPlatform? Platform { get; set; }
        public string PlatformDeviceId { get; set; }
    }
}
