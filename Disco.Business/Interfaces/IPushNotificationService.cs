using Disco.Business.Dtos.PushNotifications;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IPushNotificationService
    {
        Task SendNotificationAsync(PushNotificationBaseDto dto);
        Task SendNotificationAsync(NewFriendNotificationDto dto);
        Task SendNotificationAsync(LikeNotificationDto dto);
        Task SendNotificationAsync(AdminMessageNotificationDto dto);
    }
}
