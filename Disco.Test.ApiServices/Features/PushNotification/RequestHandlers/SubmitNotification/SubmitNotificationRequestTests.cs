namespace Disco.ApiServices.Test.Features.PushNotification.RequestHandlers.SubmitNotification
{
    using System;
    using Disco.ApiServices.Features.PushNotification.RequestHandlers.SubmitNotification;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using NUnit.Framework;

    [TestFixture]
    public class SubmitNotificationRequestTests
    {
        private SubmitNotificationRequest _testClass;
        private PushNotificationBaseDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new PushNotificationBaseDto
            {
                Title = "TestValue1990176264",
                Body = "TestValue708322548",
                Id = "TestValue1483066036",
                Tags = new[] { "TestValue1596445474", "TestValue943099688", "TestValue594169492" },
                Silent = false
            };
            _testClass = new SubmitNotificationRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new SubmitNotificationRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new SubmitNotificationRequest(default(PushNotificationBaseDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}