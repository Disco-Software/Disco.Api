using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface INotificationRepository : IRepository<Notification, int>
    {
    }
}
