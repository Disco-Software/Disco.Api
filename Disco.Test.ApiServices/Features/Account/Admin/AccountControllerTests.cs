namespace Disco.Test.ApiServices.Features.Account.Admin
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Account.Admin;
    using Disco.Business.Interfaces.Dtos.Account;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class AccountControllerTests
    {
        private AccountController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new AccountController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallLogIn()
        {
            // Arrange
            var dto = new LoginDto
            {
                Email = "TestValue956838770",
                Password = "TestValue804636134"
            };

            // Act
            var result = await _testClass.LogIn(dto);

            // Assert
            Assert.IsNotNull(result);

            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallRefreshToken()
        {
            // Arrange
            var dto = new RefreshTokenDto
            {
                RefreshToken = "TestValue1235347776",
                AccessToken = "TestValue173300663"
            };

            // Act
            var result = await _testClass.RefreshToken(dto);

            // Assert
            Assert.IsNotNull(result);

            _mediator.Received(1);
        }
    }
}