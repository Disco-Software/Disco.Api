namespace Disco.Domain.Publishers.Test.Publisher
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using Disco.Domain.Events.Dto;
    using Disco.Domain.Events.Events;
    using Disco.Intergration.EventPublisher.Publisher;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ServiceBusPublisherTests
    {
        private ServiceBusPublisher _testClass;
        private Mock<ServiceBusClient> _serviceBusClient;

        [SetUp]
        public void SetUp()
        {
            _serviceBusClient = new Mock<ServiceBusClient>("Endpoint=sb://test-service-bus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Fm//OGuOYfcs9I84CNq/VXVGbKkF5f+EV+ASbCjNJcs=");
            _testClass = new ServiceBusPublisher(_serviceBusClient.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ServiceBusPublisher(_serviceBusClient.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallPublishAsync()
        {
            // Arrange
            var @event = new PostCreatedEvent
            {
                Description = "TestValue404381313",
                PostImages = new List<PostImageDto>(),
                PostSongs = new List<PostSongDto>(),
                PostVideos = new List<PostSongDto>(),
                Likes = new List<LikeDto>(),
                DateOfCreation = DateTime.UtcNow,
                Account = new AccountDto
                {
                    Id = 93973627,
                    Photo = "TestValue477867647",
                    UserFollowerDtos = new List<UserFollowerDto>(),
                    UserFollowingDtos = new List<UserFollowerDto>(),
                    UserDto = new UserDto
                    {
                        Id = 154862973,
                        UserName = "TestValue2034937729"
                    }
                }
            };

            var mockServiceBusSender = new Mock<ServiceBusSender>();
            mockServiceBusSender
                .Setup(x => x.SendMessageAsync(It.IsAny<ServiceBusMessage>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);


            _serviceBusClient
                .Setup(x => x.CreateSender(It.IsAny<string>()))
                .Returns(mockServiceBusSender.Object);

            // Act
            await _testClass.PublishAsync(@event);

            // Assert
            _serviceBusClient.Verify(x => x.CreateSender(It.IsAny<string>()), Times.Once());
            mockServiceBusSender.Verify(x => x.CreateMessageBatchAsync(CancellationToken.None), Times.Once());
            mockServiceBusSender.Verify(x => x.SendMessageAsync(It.IsAny<ServiceBusMessage>(), CancellationToken.None), Times.Once());
        }

        [Test]
        public void CannotCallPublishAsyncWithNullEvent()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.PublishAsync(default(PostCreatedEvent)));
        }
    }
}