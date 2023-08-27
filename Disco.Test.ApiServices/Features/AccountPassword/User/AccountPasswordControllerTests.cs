namespace Disco.Test.ApiServices.Features.AccountPassword.User
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountPassword.User;
    using Disco.Business.Interfaces.Dtos.Account;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class AccountPasswordControllerTests
    {
        private AccountPasswordController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new AccountPasswordController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountPasswordController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullMediator()
        {
            Assert.Throws<ArgumentNullException>(() => new AccountPasswordController(default(IMediator)));
        }

        [Test]
        public async Task CanCallForgotPassword()
        {
            // Arrange
            var dto = new ForgotPasswordDto { Email = "TestValue1993193742" };

            // Act
            var result = await _testClass.ForgotPassword(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallForgotPasswordWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.ForgotPassword(default(ForgotPasswordDto)));
        }

        [Test]
        public async Task CanCallResetPassword()
        {
            // Arrange
            var dto = new ResetPasswordDto
            {
                Email = "TestValue231044569",
                ConfirmationToken = "TestValue1374875179",
                Password = "TestValue951607440",
                ConfirmPassword = "TestValue430811644"
            };

            // Act
            var result = await _testClass.ResetPassword(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallResetPasswordWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.ResetPassword(default(ResetPasswordDto)));
        }
    }
}