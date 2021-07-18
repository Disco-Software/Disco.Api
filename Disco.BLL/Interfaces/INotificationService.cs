using Disco.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string title, string body, NotificationTypes notificationType, string id, string tag);
    }
}
