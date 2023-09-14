namespace Disco.ApiServices.Test.Features.PushNotification.RequestHandlers.SubmitNotification
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.PushNotification.RequestHandlers.SubmitNotification;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using Disco.Business.Interfaces.Interfaces;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class SubmitNotificationRequestHandlerTests
    {
        private SubmitNotificationRequestHandler _testClass;
        private IPushNotificationService _notificationService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _notificationService = Substitute.For<IPushNotificationService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new SubmitNotificationRequestHandler(_notificationService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new SubmitNotificationRequestHandler(_notificationService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new SubmitNotificationRequest(new PushNotificationBaseDto
            {
                Title = "TestValue1461503929",
                Body = "TestValue1431423261",
                Id = "TestValue1928851822",
                Tags = new[] { "TestValue1917036982", "TestValue86897727", "TestValue661933944" },
                Silent = true
            });
            var cancellationToken = CancellationToken.None;

            _notificationService.RequestNotificationAsync(Arg.Any<PushNotificationBaseDto>(), Arg.Any<CancellationToken>()).Returns(true);
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _notificationService.Received().RequestNotificationAsync(Arg.Any<PushNotificationBaseDto>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(SubmitNotificationRequest), CancellationToken.None));
        }
    }
}