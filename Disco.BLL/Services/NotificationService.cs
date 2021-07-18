using Disco.BLL.Infrastructure;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Models;
using Disco.DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;
using FirebaseAdmin.Auth;
using Disco.DAL.Identity;
using System.Security.Claims;
using Microsoft.Azure.NotificationHubs;

namespace Disco.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationHubClient notificationHubClient;

        public NotificationService(INotificationHubClient _notificationHubClient) =>
            this.notificationHubClient = _notificationHubClient;

        public async Task SendNotificationAsync(string title, string body, NotificationTypes notificationType, string id, string tag)
        {
            var notificationPayload = $"\"title\":\"{title}\",\"body\":\"{body}\"";
            var dataPayload = $"\"type\":\"{notificationType}\",\"id\":\"{id}\", \"utcTime\": \"{DateTime.UtcNow}\"";

            var androidPayload = $"{{\"notification\":{{{notificationPayload}}},\"data\":{{{dataPayload}}}, \"sound\": \"default\"}}";
            var androidTask = notificationHubClient.SendFcmNativeNotificationAsync(androidPayload, tag);

            var applePayload = $"{{\"aps\":{{\"alert\":{{{notificationPayload},\"data\":{{{dataPayload}}}}}, \"sound\": \"default\"}}}}";
            var appleTask = notificationHubClient.SendAppleNativeNotificationAsync(applePayload, tag);
            await Task.WhenAll(androidTask, appleTask);

        }
    }
}
