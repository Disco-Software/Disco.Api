using Disco.Business.Dtos.PushNotifications;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IPushNotificationService
    {
        Task SendNotificationAsync(PushNotificationBaseDto model);

        Task SendNewFriendNotificationAsync(NewFriendNotificationDto model);
        Task SendFriendConfirmationNotificationAsync(PushNotificationBaseDto model);
        Task SendLikeNotificationAsync(LikeNotificationDto dto);
    }
}
