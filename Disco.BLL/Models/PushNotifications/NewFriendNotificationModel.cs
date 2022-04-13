using Disco.BLL.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.PushNotifications
{
    public class NewFriendNotificationModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Id { get; set; }
        public string Tags { get; set; }
        public string NotificationType { get; set; }
        public int FriendId { get; set; }

    }
}
