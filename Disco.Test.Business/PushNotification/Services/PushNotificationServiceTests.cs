namespace Disco.Test.Business.PushNotification.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using Disco.Business.Services.Services;
    using Microsoft.Azure.NotificationHubs;
    using Microsoft.Azure.NotificationHubs.Messaging;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class PushNotificationServiceTests
    {
        private PushNotificationService _testClass;
        private Mock<ILogger<PushNotificationService>> _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger<PushNotificationService>>();
            _testClass = new PushNotificationService(_logger.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new PushNotificationService(_logger.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateOrUpdateInstallationAsync()
        {
            // Arrange
            var dto = new DeviceInstallationDto
            {
                InstallationId = "TestValue1263664311",
                Platform = NotificationPlatform.Apns,
                PlatformDeviceId = "TestValue2008059513",
                PushChannel = "TestValue823928858",
                Tags = new[] { "TestValue1530447738", "TestValue2005442766", "TestValue1530180429" }
            };
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _testClass.CreateOrUpdateInstallationAsync(dto, cancellationToken);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CanCallDeleteInstallationByIdAsync()
        {
            // Arrange
            var installationId = "TestValue1616392515";
            var token = CancellationToken.None;

            // Act
            var result = await _testClass.DeleteInstallationByIdAsync(installationId, token);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CanCallRequestNotificationAsync()
        {
            // Arrange
            var dto = new PushNotificationBaseDto
            {
                Title = "TestValue425616999",
                Body = "TestValue42770622",
                Id = "TestValue42005807",
                Tags = new[] { "TestValue1622199099", "TestValue343487368", "TestValue1176256100" },
                Silent = true
            };
            var token = CancellationToken.None;

            // Act
            var result = await _testClass.RequestNotificationAsync(dto, token);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CannotCallRequestNotificationAsyncWithNullDto()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.RequestNotificationAsync(default, CancellationToken.None));
        }

        private Mock<INotificationHubClient> AddAzureNotificationHubClientMock()
        {
            var mockNotificationHubClient = new Mock<INotificationHubClient>();
            mockNotificationHubClient.Setup(x => x.CreateOrUpdateInstallation(It.IsAny<Installation>()))
                .Verifiable();
            mockNotificationHubClient.Setup(x => x.DeleteInstallation(It.IsAny<string>()))
                .Verifiable();

            return mockNotificationHubClient;
        }
    }
}