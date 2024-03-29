﻿using Disco.Business.Interfaces.Dtos.NewsNotification.Admin.NewsNotificationEvent;
using Disco.Business.Interfaces.Dtos.PushNotifications;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.Azure.NotificationHubs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IPushNotificationService
    {
        Task<string> CreateOrUpdateInstallationAsync(DeviceInstallationDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteInstallationByIdAsync(string installationId, CancellationToken token = default);
        Task<Installation> GetInstallationAsync(string installationId, CancellationToken token = default);
        Task RequestNotificationAsync(NewsNotificationEventDto dto, IEnumerable<User> users);
    }
}
