using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Constants
{
    public class NotificationTemplates
    {
        public class PayloadNotification
        {
            public const string Android = "{ \"notification\": { \"title\" : \"$(titleMessage)\", \"body\" : \"$(alertMessage)\"}, \"data\" : { \"action\" : \"$(alertAction)\" } }";
            public const string iOS = "{ \"aps\" : {\"alert\" : \"$(alertMessage)\"}, \"action\" : \"$(alertAction)\" }";
        }

        public class DataNotification
        {
            public const string Android = "{ \"data\" : {\"message\" : \"$(alertMessage)\", \"action\" : \"$(alertAction)\"} }";
            public const string iOS = "{ \"aps\" : {\"content-available\" : 1, \"apns-priority\": 5, \"sound\" : \"default\", \"badge\" : 0}, \"message\" : \"$(alertMessage)\", \"action\" : \"$(alertAction)\" }";
        }

    }
}
