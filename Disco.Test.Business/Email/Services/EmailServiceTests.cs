namespace Disco.Test.Business.Email.Services
{
    using System;
    using Disco.Business.Interfaces.Dtos.EmailNotifications;
    using Disco.Business.Interfaces.Dtos.EmailNotifications.User.EmailConfirmation;
    using Disco.Business.Interfaces.Options;
    using Disco.Business.Services.Services;
    using MailKit.Net.Smtp;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class EmailServiceTests
    {
        private EmailService _testClass;
        
        private Mock<IOptions<EmailOptions>> _emailOptions;
        private Mock<ISmtpClient> _smtpClient;

        [SetUp]
        public void SetUp()
        {
            _emailOptions = new Mock<IOptions<EmailOptions>>();
            _smtpClient = new Mock<ISmtpClient>();

            _testClass = new EmailService(_emailOptions.Object, _smtpClient.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new EmailService(_emailOptions.Object, _smtpClient.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallEmailConfirmation()
        {
            // Arrange
            var model = new EmailConfirmationRequestDto(
                "developer.disco@gmail.com",
                "Disco",
                "TestValue1311457304",
                "TestValue780352646",
                333333,
                true
            );

            _emailOptions.Setup(x => x.Value)
                .Returns(new EmailOptions
                {
                    Host = "smtp.gmail.com",
                    Mail = "developer.disco@gmail.com",
                    Name = "DISCO",
                    Password = "vjazelblozgblypf",
                    Port = 587
                });

            // Act
            _testClass.EmailConfirmationAsync(model);

            // Assert
            _emailOptions.VerifyAll();
            _smtpClient.VerifyAll();
        }

        [Test]
        public void CannotCallEmailConfirmationWithNullModel()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.EmailConfirmationAsync(default));
        }
    }
}