using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dto.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly NotificationHubClient notificationHubClient;
        private readonly IConfiguration configuration;
        public PushNotificationService(IConfiguration _configuration)
        {
            notificationHubClient = NotificationHubClient.CreateClientFromConnectionString(configuration[
                Strings.NOTIFICATION_CONNECTION_STRING],
                configuration[Strings.NOTIFICATION_NAME]);
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
            var androidTask = notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, model.Tag);

            var applePayload = $"{{\"aps\":{{\"content-available\":1,\"alert\":{{{notificationPayload},\"data\":{{{dataPayload}}}}}, \"sound\": \"default\"}}, \"key-value\" : {{\"type\" : \"{model.NotificationType}\", \"id\" : \"{model.Id}\"}}}}";
            var appleTask = notificationHubClient.SendAppleNativeNotificationAsync(applePayload, model.Tag);
            await Task.WhenAll(androidTask, appleTask);
        }
        public async Task SendNotificationAsync(NewFriendNotificationDto model)
        {
            var notificationPayload = $"\"title\":\"{model.Title}\",\"body\":\"{model.Body}\"";
            var dataPayload = $"\"type\":\"{model.NotificationType}\",\"id\":\"{model.Id}\"";

            var androidPayload = $"{{\"notification\":{{}},\"data\":{{{dataPayload}}}, \"sound\": \"default\"}}";
            var androidTask = notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, model.Tags);

            var applePayload = $"{{\"aps\":{{\"content-available\":1,\"alert\":{{{notificationPayload},\"data\":{{{dataPayload}}}}}, \"sound\": \"default\"}}, \"key-value\" : {{\"type\" : \"{model.NotificationType}\", \"id\" : \"{model.Id}\"}}}}";
            var appleTask = notificationHubClient.SendAppleNativeNotificationAsync(applePayload, model.Tags);
            await Task.WhenAll(androidTask, appleTask);
        }

        public async Task SendNewFriendNotificationAsync(NewFriendNotificationDto model)
        {
            await SendNotificationAsync(new NewFriendNotificationDto
            {
                Title = model.Title,
                Body = model.Body,
                FriendId = model.FriendId,
                NotificationType = NotificationTypes.NewFollower,
                Tags = $"user-{model.FriendId}",
            });
        }

        public async Task SendFriendConfirmationNotificationAsync(PushNotificationBaseDto model)
        {
            throw new NotImplementedException();
        }
    }
}
