using Disco.Business.Interfaces.Dtos.PushNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.NewsNotification.Admin.SendNewsNotification
{
    public class SendNewsNotificationRequestDto : PushNotificationBaseDto
    {
        public SendNewsNotificationRequestDto(
            IEnumerable<string> userNames)
        {
            UserNames = userNames;
        }

        public IEnumerable<string> UserNames { get; set; }
    }
}
