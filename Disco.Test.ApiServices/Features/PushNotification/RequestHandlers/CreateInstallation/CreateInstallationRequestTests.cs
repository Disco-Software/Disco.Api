namespace Disco.ApiServices.Test.Features.PushNotification.RequestHandlers.CreateInstallation
{
    using System;
    using System.Collections.Generic;
    using Disco.ApiServices.Features.PushNotification.RequestHandlers.CreateInstallation;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using Microsoft.Azure.NotificationHubs;
    using NUnit.Framework;

    [TestFixture]
    public class CreateInstallationRequestTests
    {
        private CreateInstallationRequest _testClass;
        private DeviceInstallationDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new DeviceInstallationDto
            {
                InstallationId = "TestValue1562996238",
                Platform = new NotificationPlatform?(),
                PlatformDeviceId = "TestValue707717722",
                PushChannel = "TestValue1213487111",
                Tags = new[] { "TestValue1818633913", "TestValue1596986565", "TestValue424542092" }
            };
            _testClass = new CreateInstallationRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateInstallationRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateInstallationRequest(default(DeviceInstallationDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}