using Azure.Messaging.ServiceBus;
using Disco.Domain.Events.Events;
using Disco.Integration.Interfaces.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Intergration.EventPublisher.Publisher
{
    public class ServiceBusPublisher : IEventPublisher
    {
        private readonly ServiceBusClient _serviceBusClient;

        public ServiceBusPublisher(ServiceBusClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }

        public async Task PublishAsync(PostCreatedEvent @event)
        {
            var sender = _serviceBusClient.CreateSender("post-created-event");

            using var messageBatch = await sender.CreateMessageBatchAsync();

            var json = JsonConvert.SerializeObject(@event);

            await sender.SendMessageAsync(new ServiceBusMessage(json));
        }
    }
}
