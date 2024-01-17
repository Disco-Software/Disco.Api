using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Constants
{
    public class NotificationTemplates
    {
        public class DataNotification
        {
            public const string ADMIN_NOTIFICATION = "\"type\":\"(type)\"," +
                $"\"senderName\" : \"(name)\"," +
                $"\"senderPhoto\" : \"(photo)\"," +
                $"\"date\" : \"(date)\"," +
                $"\"message\" : \"(message)\"";
        }

    }
}
