﻿using Disco.BLL.Dto.PushNotifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IPushNotificationService
    {
        Task SendNotificationAsync(PushNotificationBaseDto model);

        Task SendNewFriendNotificationAsync(NewFriendNotificationDto model);
        Task SendFriendConfirmationNotificationAsync(PushNotificationBaseDto model);
    }
}
