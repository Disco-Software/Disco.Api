namespace Disco.Test.Business.Features.Account.User.RequestHandlers.Registration
{
    using System;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.Registration;
    using Disco.Business.Interfaces.Dtos.Account;
    using NUnit.Framework;

    [TestFixture]
    public class RegistrationRequestTests
    {
        private RegistrationRequest _testClass;
        private RegistrationDto _registration;

        [SetUp]
        public void SetUp()
        {
            _registration = new RegistrationDto
            {
                UserName = "TestValue2061530714",
                Email = "TestValue1666056837",
                Password = "TestValue1940597786",
                ConfirmPassword = "TestValue1888369358"
            };
            _testClass = new RegistrationRequest(_registration);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RegistrationRequest(_registration);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullRegistration()
        {
            Assert.Throws<ArgumentNullException>(() => new RegistrationRequest(default(RegistrationDto)));
        }

        [Test]
        public void RegistrationIsInitializedCorrectly()
        {
            Assert.That(_testClass.Registration, Is.SameAs(_registration));
        }
    }
}