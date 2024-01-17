using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface INotificationRepository : IRepository<Notification, int>
    {
        Task<List<Notification>> GetAllNotificationsAsync(int accountId, int pageNumber, int pageSize);
    }
}
