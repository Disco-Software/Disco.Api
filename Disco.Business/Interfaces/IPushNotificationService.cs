using Disco.Business.Dtos.PushNotifications;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IPushNotificationService
    {
        Task SendNotificationAsync(PushNotificationBaseDto dto);
        Task SendNotificationAsync(NewFriendNotificationDto dto);
        Task SendNotificationAsync(LikeNotificationDto dto);
        Task SendNotificationAsync(AdminMessageNotificationDto dto);
        Task<IEnumerable<User>> SubscribeUserAsync(User user, int instalationId, int notificationId);
    }
}
