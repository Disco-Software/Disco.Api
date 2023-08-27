namespace Disco.ApiServices.Test.Features.PushNotification
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.PushNotification;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using MediatR;
    using Microsoft.Azure.NotificationHubs;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class PushNotificationsControllerTests
    {
        private PushNotificationsController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new PushNotificationsController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new PushNotificationsController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullMediator()
        {
            Assert.Throws<ArgumentNullException>(() => new PushNotificationsController(default(IMediator)));
        }

        [Test]
        public async Task CanCallCreateInstallationAsync()
        {
            // Arrange
            var dto = new DeviceInstallationDto
            {
                InstallationId = "TestValue1507558006",
                Platform = new NotificationPlatform?(),
                PlatformDeviceId = "TestValue855299113",
                PushChannel = "TestValue341767899",
                Tags = new[] { "TestValue1771521079", "TestValue2093784643", "TestValue85593048" }
            };

            // Act
            var result = await _testClass.CreateInstallationAsync(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateInstallationAsyncWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.CreateInstallationAsync(default(DeviceInstallationDto)));
        }

        [Test]
        public async Task CanCallRemoveInstallationAsync()
        {
            // Arrange
            var installationId = "TestValue262638249";

            // Act
            var result = await _testClass.RemoveInstallationAsync(installationId);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallRemoveInstallationAsyncWithInvalidInstallationId(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.RemoveInstallationAsync(value));
        }

        [Test]
        public async Task CanCallSubmitNotificationAsync()
        {
            // Arrange
            var dto = new PushNotificationBaseDto
            {
                Title = "TestValue914018149",
                Body = "TestValue497142034",
                Id = "TestValue1938333782",
                Tags = new[] { "TestValue874446085", "TestValue1733282144", "TestValue417560472" },
                Silent = true
            };

            // Act
            var result = await _testClass.SubmitNotificationAsync(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallSubmitNotificationAsyncWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.SubmitNotificationAsync(default(PushNotificationBaseDto)));
        }
    }
}