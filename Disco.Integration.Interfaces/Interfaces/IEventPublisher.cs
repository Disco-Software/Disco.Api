using Disco.Domain.Events.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Integration.Interfaces.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync(PostCreatedEvent @event);
    }
}
