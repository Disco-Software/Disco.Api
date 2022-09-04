using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly NotificationHubClient _notificationHubClient;
        private readonly IConfiguration _configuration;
        public PushNotificationService(IConfiguration configuration)
        {
            _notificationHubClient = NotificationHubClient.CreateClientFromConnectionString(_configuration[
                Strings.NotificationConnectionString],
                _configuration[Strings.NotificationName]);
        }


        /// <summary>
        /// Sends push notifications to android and ios devices
        /// </summary>
        /// <param name="model">base params of notification</param>
        /// <returns></returns>
        public async Task SendNotificationAsync(PushNotificationBaseDto model)
        {
            var notificationPayload = $"\"title\":\"{model.Title}\",\"body\":\"{model.Body}\"";
            var dataPayload = $"\"type\":\"{model.NotificationType}\",\"id\":\"{model.Id}\"";

            var androidPayload = $"{{\"notification\":{{}},\"data\":{{{dataPayload}}}, \"sound\": \"default\"}}";
            var androidTask = _notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, model.Tag);

            var applePayload = $"{{\"aps\":{{\"content-available\":1,\"alert\":{{{notificationPayload},\"data\":{{{dataPayload}}}}}, \"sound\": \"default\"}}, \"key-value\" : {{\"type\" : \"{model.NotificationType}\", \"id\" : \"{model.Id}\"}}}}";
            var appleTask = _notificationHubClient.SendAppleNativeNotificationAsync(applePayload, model.Tag);
            await Task.WhenAll(androidTask, appleTask);
        }
        public async Task SendNotificationAsync(NewFriendNotificationDto model)
        {
            var notificationPayload = $"\"title\":\"{model.Title}\",\"body\":\"{model.Body}\"";
            var dataPayload = $"\"type\":\"{model.NotificationType}\",\"id\":\"{model.Id}\"";

            var androidPayload = $"{{\"notification\":{{}},\"data\":{{{dataPayload}}}, \"sound\": \"default\"}}";
            var androidTask = _notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, model.Tags);

            var applePayload = $"{{\"aps\":{{\"content-available\":1,\"alert\":{{{notificationPayload},\"data\":{{{dataPayload}}}}}, \"sound\": \"default\"}}, \"key-value\" : {{\"type\" : \"{model.NotificationType}\", \"id\" : \"{model.Id}\"}}}}";
            var appleTask = _notificationHubClient.SendAppleNativeNotificationAsync(applePayload, model.Tags);
            await Task.WhenAll(androidTask, appleTask);
        }

        public async Task SendNewFriendNotificationAsync(NewFriendNotificationDto model)
        {
            await SendNotificationAsync(new NewFriendNotificationDto
            {
                Title = model.Title,
                Body = model.Body,
                FriendId = model.FriendId,
                NotificationType = NotificationTypes.NewFollowerNotification,
                Tags = $"user-{model.FriendId}",
            });
        }

        public async Task SendFriendConfirmationNotificationAsync(PushNotificationBaseDto model)
        {
            throw new NotImplementedException();
        }
    }
}
