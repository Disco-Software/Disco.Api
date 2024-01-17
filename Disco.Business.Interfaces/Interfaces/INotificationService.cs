using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface INotificationService
    {
        Task CreateAsync(Notification notification);
        Task DeleteAsync(Notification notification);
        Task<IEnumerable<Notification>> GetAllAsync(int id, int pageNumber, int pageSize);
    }
}
