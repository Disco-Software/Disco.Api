using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(
            INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task CreateAsync(Notification notification)
        {
            await _notificationRepository.AddAsync(notification);
        }

        public async Task DeleteAsync(Notification notification)
        {
            notification.Account.Notifications.Remove(notification);

            await _notificationRepository.RemoveAsync(notification);
        }

        public async Task<IEnumerable<Notification>> GetAllAsync(int id, int pageNumber, int pageSize)
        {
            return await _notificationRepository.GetAllNotificationsAsync(id, pageNumber, pageSize);
        }
    }
}
