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
        public PushNotificationService(IConfiguration configuration)
        {
            _notificationHubClient = NotificationHubClient.CreateClientFromConnectionString(Strings.NotificationConnectionString, Strings.NotificationName);
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
        
        public async Task SendNotificationAsync(LikeNotificationDto dto)
        {
            var notificationPayload = $"\"title\":\"{dto.Title}\",\"body\":\"{dto.Body}\"";
            var dataPayload = $"\"type\":\"{dto.NotificationType}\", \"id\" : \"{dto.Id}\",\"likes\":\"{dto.LikesCount}\"";

            var androidPayload = $"{{\"notification\":{{}},\"data\":{{{dataPayload}}}, \"sound\": \"default\"}}";
            var androidTask = _notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, dto.Tags);

            //var applePayload = $"{{\"aps\":{{\"content-available\":1,\"alert\":{{{notificationPayload},\"data\":{{{dataPayload}}}}}, \"sound\": \"default\"}}, \"key-value\" : {{\"type\" : \"{dto.NotificationType}\", \"id\" : \"{dto.Id}\"}}}}";
            //var appleTask = _notificationHubClient.SendAppleNativeNotificationAsync(applePayload, dto.Tags);
            
            await Task.WhenAll(androidTask);
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

        public async Task SendLikeNotificationAsync(LikeNotificationDto dto)
        {
            await SendNotificationAsync(new LikeNotificationDto
            {
                Title = dto.Title,
                Body = dto.Body,
                NotificationType = NotificationTypes.LikeNotification,
                Id = dto.Id,
                Tags = dto.Tags,
                LikesCount = dto.LikesCount,
            });
        }
    }
}
