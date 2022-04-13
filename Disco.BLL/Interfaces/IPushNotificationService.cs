using Disco.BLL.Models.PushNotifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IPushNotificationService
    {
        Task SendNotificationAsync(PushNotificationBaseModel model);

        Task SendNewFriendNotificationAsync(NewFriendNotificationModel model);
        Task SendFriendConfirmationNotificationAsync(PushNotificationBaseModel model);
    }
}
