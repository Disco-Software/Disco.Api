using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Interfaces.Dtos.PushNotifications
{
    public class AdminMessageNotificationDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }
        public string NotificationType { get; set; }
    }
}
