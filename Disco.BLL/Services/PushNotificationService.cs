using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly NotificationHubClient notificationHubClient;

        public PushNotificationService(NotificationHubClient _notificationHubClient) =>
            notificationHubClient = _notificationHubClient;


        /// <summary>
        /// Sends push notifications to android and ios devices
        /// </summary>
        /// <param name="model">base params of notification</param>
        /// <returns></returns>
        public async Task SendNotificationAsync(PushNotificationBaseModel model)
        {
            var notificationPayload = $"\"title\":\"{model.Title}\",\"body\":\"{model.Body}\"";
            var dataPayload = $"\"type\":\"{model.NotificationType}\",\"id\":\"{model.Id}\"";

            var androidPayload = $"{{\"notification\":{{}},\"data\":{{{dataPayload}}}, \"sound\": \"default\"}}";
            var androidTask = notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, model.Tag);

            var applePayload = $"{{\"aps\":{{\"content-available\":1,\"alert\":{{{notificationPayload},\"data\":{{{dataPayload}}}}}, \"sound\": \"default\"}}, \"key-value\" : {{\"type\" : \"{model.NotificationType}\", \"id\" : \"{model.Id}\"}}}}";
            var appleTask = notificationHubClient.SendAppleNativeNotificationAsync(applePayload, model.Tag);
            await Task.WhenAll(androidTask, appleTask);
        }
        public async Task SendNotificationAsync(NewFriendNotificationModel model)
        {
            var notificationPayload = $"\"title\":\"{model.Title}\",\"body\":\"{model.Body}\"";
            var dataPayload = $"\"type\":\"{model.NotificationType}\",\"id\":\"{model.Id}\"";

            var androidPayload = $"{{\"notification\":{{}},\"data\":{{{dataPayload}}}, \"sound\": \"default\"}}";
            var androidTask = notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, model.Tags);

            var applePayload = $"{{\"aps\":{{\"content-available\":1,\"alert\":{{{notificationPayload},\"data\":{{{dataPayload}}}}}, \"sound\": \"default\"}}, \"key-value\" : {{\"type\" : \"{model.NotificationType}\", \"id\" : \"{model.Id}\"}}}}";
            var appleTask = notificationHubClient.SendAppleNativeNotificationAsync(applePayload, model.Tags);
            await Task.WhenAll(androidTask, appleTask);
        }

        public async Task SendNewFriendNotificationAsync(NewFriendNotificationModel model)
        {
            await SendNotificationAsync(new NewFriendNotificationModel
            {
                Title = model.Title,
                Body = model.Body,
                FriendId = model.FriendId,
                NotificationType = NotificationTypes.NewFollower,
                Tags = $"user-{model.FriendId}",
            });
        }

        public async Task SendFriendConfirmationNotificationAsync(PushNotificationBaseModel model)
        {
            throw new NotImplementedException();
        }
    }
}
