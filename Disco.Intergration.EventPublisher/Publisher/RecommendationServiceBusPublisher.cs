using Azure.Messaging.ServiceBus;
using Disco.Domain.Events.Events;
using Disco.Integration.Interfaces.Interfaces;
using Newtonsoft.Json;

namespace Disco.Intergration.EventPublisher.Publisher
{
    public class RecommendationServiceBusPublisher : IRecommendationServiceBusPublisher
    {
        private readonly ServiceBusClient _serviceBusClient;

        public RecommendationServiceBusPublisher(ServiceBusClient serviceBusClient)
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
