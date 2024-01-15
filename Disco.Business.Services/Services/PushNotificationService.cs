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
using Disco.Domain.Models.Models;
using Disco.Business.Utils.Guards;

namespace Disco.Business.Services.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly INotificationHubClient _notificationHubClient;
        private readonly Dictionary<string, NotificationPlatform> _installationPlatform;
        private readonly ILogger<PushNotificationService> _logger;

        public PushNotificationService(ILogger<PushNotificationService> logger)
        {
            _logger = logger;
            _notificationHubClient = NotificationHubClient.CreateClientFromConnectionString(Strings.NotificationConnectionString, Strings.NotificationName);
            _installationPlatform = new Dictionary<string, NotificationPlatform>
            {
                {nameof(NotificationPlatform.Fcm), NotificationPlatform.Fcm },
                {nameof(NotificationPlatform.Apns), NotificationPlatform.Apns }
            };

            DefaultGuard.ArgumentNull(_notificationHubClient);
            DefaultGuard.ArgumentNull(_installationPlatform);
            DefaultGuard.ArgumentNull(_logger);
        }

        public async Task<string> CreateOrUpdateInstallationAsync(DeviceInstallationDto dto, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(dto.InstallationId))
            {
                var installation = await this.GetInstallation(dto);

                installation.PushChannel = dto.PlatformDeviceId;
                installation.PushChannelExpired = false;

                await _notificationHubClient.CreateOrUpdateInstallationAsync(installation);

                return dto.InstallationId;
            }

            var installationId = Guid.NewGuid().ToString();

            await _notificationHubClient.CreateOrUpdateInstallationAsync(
                new Installation
                {
                    InstallationId = installationId,
                    Platform = dto.Platform!.Value,
                    PushChannel = dto.PlatformDeviceId
                },
                cancellationToken);

            return installationId;
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

        public async Task<Installation> GetInstallationAsync(string installationId, CancellationToken token = default)
        {
            var installation = await _notificationHubClient.GetInstallationAsync(installationId, token);

            return installation;
        }

        public async Task RequestNotificationAsync(PushNotificationBaseDto dto, IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                var tags = new List<string> { user.Id.ToString() };

                try
                {
                    await this.SendNotificationAsync(dto.Title, dto.Body, user.UserName!, tags.FirstOrDefault()!, CancellationToken.None);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private async Task SendNotificationAsync(string title, string body, string userName, string tag,CancellationToken cancellationToken)
        {
            var dataPayload = "\"title\":\"Notification Title\",\"body\":\"Hello, world!\"";

            //var iosPayload = $"{{\"aps\":{{\"alert\":{{\"title\":\"Notification Title\",\"body\":\"Hello, world!\"}},\"sound\":\"default\"}},\"data\":{{{dataPayload}}}}}";
            //var iosTask = _notificationHubClient.SendAppleNativeNotificationAsync(iosPayload, tag, cancellationToken);

            var androidPayload = $"{{\"notification\":{{}},\"data\":{{{dataPayload}}}, \"sound\": \"default\"}}";
            var androidTask = _notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, tag, cancellationToken);

            await Task.WhenAll(androidTask);
        }


        private async Task<Installation> GetInstallation(DeviceInstallationDto dto)
        {
            try
            {
                return await _notificationHubClient.GetInstallationAsync(dto.InstallationId);
            }
            catch (Exception ex)
            {
                return new Installation
                {
                    InstallationId = dto.InstallationId,
                    Platform = dto.Platform!.Value
                };
            }
        }

    }
}
