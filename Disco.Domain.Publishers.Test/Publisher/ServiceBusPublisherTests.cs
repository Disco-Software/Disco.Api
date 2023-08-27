namespace Disco.Domain.Publishers.Test.Publisher
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using Disco.Domain.Events.Dto;
    using Disco.Domain.Events.Events;
    using Disco.Intergration.EventPublisher.Publisher;
    using NUnit.Framework;

    [TestFixture]
    public class ServiceBusPublisherTests
    {
        private ServiceBusPublisher _testClass;
        private ServiceBusClient _serviceBusClient;

        [SetUp]
        public void SetUp()
        {
            _serviceBusClient = new ServiceBusClient("TestValue440853823");
            _testClass = new ServiceBusPublisher(_serviceBusClient);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ServiceBusPublisher(_serviceBusClient);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullServiceBusClient()
        {
            Assert.Throws<ArgumentNullException>(() => new ServiceBusPublisher(default(ServiceBusClient)));
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

            // Act
            await _testClass.PublishAsync(@event);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallPublishAsyncWithNullEvent()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.PublishAsync(default(PostCreatedEvent)));
        }
    }
}