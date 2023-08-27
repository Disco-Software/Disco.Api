namespace Disco.ApiServices.Test.Features.PushNotification.RequestHandlers.CreateInstallation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.PushNotification.RequestHandlers.CreateInstallation;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using Disco.Business.Interfaces.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Azure.NotificationHubs;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CreateInstallationRequestHandlerTests
    {
        private CreateInstallationRequestHandler _testClass;
        private IPushNotificationService _notificationService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _notificationService = Substitute.For<IPushNotificationService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new CreateInstallationRequestHandler(_notificationService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateInstallationRequestHandler(_notificationService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullNotificationService()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateInstallationRequestHandler(default(IPushNotificationService), _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateInstallationRequestHandler(_notificationService, default(IHttpContextAccessor)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new CreateInstallationRequest(new DeviceInstallationDto
            {
                InstallationId = "TestValue1174718395",
                Platform = new NotificationPlatform?(),
                PlatformDeviceId = "TestValue296647927",
                PushChannel = "TestValue1954200802",
                Tags = new[] { "TestValue1373084329", "TestValue1917805028", "TestValue2055337549" }
            });
            var cancellationToken = CancellationToken.None;

            _notificationService.CreateOrUpdateInstallationAsync(Arg.Any<DeviceInstallationDto>(), Arg.Any<CancellationToken>()).Returns(false);
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _notificationService.Received().CreateOrUpdateInstallationAsync(Arg.Any<DeviceInstallationDto>(), Arg.Any<CancellationToken>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(CreateInstallationRequest), CancellationToken.None));
        }
    }
}