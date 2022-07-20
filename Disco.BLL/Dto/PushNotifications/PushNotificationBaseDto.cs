using Disco.Business.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dto.PushNotifications
{
    public class PushNotificationBaseDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Id { get; set; }
        public string Tag { get; set; }
        public string NotificationType { get; set; }
    }
}
