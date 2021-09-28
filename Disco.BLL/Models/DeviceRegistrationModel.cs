using Microsoft.Azure.NotificationHubs;

using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models
{
    public class DeviceRegistrationModel
    {
        public string InstallationId { get; set; }
        public NotificationPlatform? Platform { get; set; }
        public string PlatformDeviceId { get; set; }
    }
}
