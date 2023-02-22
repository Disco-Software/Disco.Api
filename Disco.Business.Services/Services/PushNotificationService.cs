using Disco.Business.Constants;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Interfaces.Dtos.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Disco.Domain.Models;
using System.Threading;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.Extensions.Options;
using Disco.Business.Interfaces.Options;
using Disco.Business.Utils.Constants;

namespace Disco.Business.Services.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly IOptions<ConnectionStringsOptions> _options;
        private readonly INotificationHubClient _notificationHubClient;
        private readonly Dictionary<string, NotificationPlatform> _installationPlatform;
        private readonly ILogger<PushNotificationService> _logger;

        public PushNotificationService(
            IOptions<ConnectionStringsOptions> options,
            ILogger<PushNotificationService> logger)
        {
            _options = options;
            _logger = logger;
            _notificationHubClient = NotificationHubClient.CreateClientFromConnectionString(_options.Value.AzureNotificationHubConnection, NotificationHubNames.NotificationName);
            _installationPlatform = new Dictionary<string, NotificationPlatform>
            {
                {nameof(NotificationPlatform.Fcm), NotificationPlatform.Fcm },
                {nameof(NotificationPlatform.Apns), NotificationPlatform.Apns }
            };
        }

        public async Task<bool> CreateOrUpdateInstallationAsync(DeviceInstallationDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto?.InstallationId) ||
                string.IsNullOrWhiteSpace(dto?.PushChannel) ||
                string.IsNullOrWhiteSpace(dto?.Platform.Value.ToString()))
                return false;

            var installation = new Installation()
            {
                InstallationId = dto.InstallationId,
                PushChannel = dto.PushChannel,
                Tags = dto.Tags
            };

            if (_installationPlatform.TryGetValue(dto.Platform.Value.ToString(), out var platform))
                installation.Platform = platform;
            else
                return false;

            try
            {
                await _notificationHubClient.CreateOrUpdateInstallationAsync(installation, cancellationToken);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteInstallationByIdAsync(string installationId, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(installationId))
                return false;

            try
            {
                await _notificationHubClient.DeleteInstallationAsync(installationId, token);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> RequestNotificationAsync(PushNotificationBaseDto dto, CancellationToken token)
        {
            var androidPushTemplate = dto.Silent ? NotificationTemplates.DataNotification.Android : NotificationTemplates.PayloadNotification.Android;
            var iOSPushTemplate = dto.Silent ? NotificationTemplates.DataNotification.iOS : NotificationTemplates.PayloadNotification.iOS;

            var androidPayload = PrepareNotificationPayload(androidPushTemplate, dto);
            var iOSPayload = PrepareNotificationPayload(iOSPushTemplate, dto);

            try
            {
                if (dto.Tags.Length == 0)
                    await SendPlatformNotificationAsync(androidPayload, iOSPayload, token);
                else if (dto.Tags.Length <= 20)
                    await SendPlatformNotificationAsync(androidPayload, iOSPayload, dto.Tags, token);
                else
                {
                    var notificationTasks = dto.Tags
                        .Select((value, index) => (value, index))
                        .GroupBy(g => g.index / 20, i => i.value)
                        .Select(tags => SendPlatformNotificationAsync(androidPayload, iOSPayload, dto.Tags, token));

                    await Task.WhenAll(notificationTasks);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error sending notifications");
                return false;
            }
        }

        private Task SendPlatformNotificationAsync(string androidPayload, string iOSPayload, CancellationToken token)
        {
            var sendTasks = new Task[]
            {
                _notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, token),
                _notificationHubClient.SendAppleNativeNotificationAsync(iOSPayload, token)
            };

            return Task.WhenAll(sendTasks);
        }

        private Task SendPlatformNotificationAsync(string androidPayload, string iOSPayload, string[] tags, CancellationToken token)
        {
            var sendTasks = new Task[]
            {
                _notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, tags, token),
                _notificationHubClient.SendAppleNativeNotificationAsync(iOSPayload, tags, token)
            };

            return Task.WhenAll(sendTasks);
        }

        private string PrepareNotificationPayload(string template, PushNotificationBaseDto dto)
        {
            var payload = template
                .Replace("$(alertMessage)", dto.Title, StringComparison.InvariantCulture)
                .Replace("$(alertAction)", dto.Body, StringComparison.InvariantCulture);

            return payload;
        }
    }
}
