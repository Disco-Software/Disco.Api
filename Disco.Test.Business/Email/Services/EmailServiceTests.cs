namespace Disco.Test.Business.Email.Services
{
    using System;
    using Disco.Business.Interfaces.Dtos.EmailNotifications;
    using Disco.Business.Interfaces.Options;
    using Disco.Business.Services.Services;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class EmailServiceTests
    {
        private EmailService _testClass;
        private Mock<IOptions<EmailOptions>> _emailOptions;

        [SetUp]
        public void SetUp()
        {
            _emailOptions = new Mock<IOptions<EmailOptions>>();
            _testClass = new EmailService(_emailOptions.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new EmailService(_emailOptions.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallEmailConfirmation()
        {
            // Arrange
            var model = new EmailConfirmationDto
            {
                ToEmail = "developer.disco@gmail.com",
                Name = "Disco",
                MessageHeader = "TestValue1311457304",
                MessageBody = "TestValue780352646",
                IsHtmlTemplate = true
            };

            // Act
            _testClass.EmailConfirmation(model);

            // Assert
            _emailOptions.VerifyAll();
        }

        [Test]
        public void CannotCallEmailConfirmationWithNullModel()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.EmailConfirmation(default));
        }
    }
}