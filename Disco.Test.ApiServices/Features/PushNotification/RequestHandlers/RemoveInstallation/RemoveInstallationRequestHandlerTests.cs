namespace Disco.ApiServices.Test.Features.PushNotification.RequestHandlers.RemoveInstallation
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.PushNotification.RequestHandlers.RemoveInstallation;
    using Disco.Business.Interfaces.Interfaces;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class RemoveInstallationRequestHandlerTests
    {
        private RemoveInstallationRequestHandler _testClass;
        private IPushNotificationService _notificationService;

        [SetUp]
        public void SetUp()
        {
            _notificationService = Substitute.For<IPushNotificationService>();
            _testClass = new RemoveInstallationRequestHandler(_notificationService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RemoveInstallationRequestHandler(_notificationService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new RemoveInstallationRequest("TestValue1424716632");
            var cancellationToken = CancellationToken.None;

            _notificationService.DeleteInstallationByIdAsync(Arg.Any<string>(), Arg.Any<CancellationToken>()).Returns(false);

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _notificationService.Received().DeleteInstallationByIdAsync(Arg.Any<string>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(RemoveInstallationRequest), CancellationToken.None));
        }
    }
}