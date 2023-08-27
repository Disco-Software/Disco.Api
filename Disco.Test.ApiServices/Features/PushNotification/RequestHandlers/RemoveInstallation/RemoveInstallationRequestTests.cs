namespace Disco.ApiServices.Test.Features.PushNotification.RequestHandlers.RemoveInstallation
{
    using System;
    using Disco.ApiServices.Features.PushNotification.RequestHandlers.RemoveInstallation;
    using NUnit.Framework;

    [TestFixture]
    public class RemoveInstallationRequestTests
    {
        private RemoveInstallationRequest _testClass;
        private string _installationId;

        [SetUp]
        public void SetUp()
        {
            _installationId = "TestValue1408620479";
            _testClass = new RemoveInstallationRequest(_installationId);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RemoveInstallationRequest(_installationId);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidInstallationId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new RemoveInstallationRequest(value));
        }

        [Test]
        public void InstallationIdIsInitializedCorrectly()
        {
            Assert.That(_testClass.InstallationId, Is.EqualTo(_installationId));
        }
    }
}