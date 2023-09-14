namespace Disco.Test.ApiServices.Features.Account.User
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Account.User;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Dtos.Apple;
    using Disco.Business.Interfaces.Dtos.Google;
    using Disco.Integration.Interfaces.Dtos.Facebook;
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
        public async Task CanCallLogInAsync()
        {
            // Arrange
            var dto = new LoginDto
            {
                Email = "TestValue990696390",
                Password = "TestValue862214219"
            };

            // Act
            var result = await _testClass.LogInAsync(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallFacebook()
        {
            // Arrange
            var dto = new FacebookRequestDto { AccessToken = "TestValue193345151" };

            // Act
            var result = await _testClass.Facebook(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGoogle()
        {
            // Arrange
            var dto = new GoogleLogInDto
            {
                Email = "TestValue1067552795",
                UserName = "TestValue694835624",
                Photo = "TestValue270693058",
                Id = "TestValue974548716",
                IdToken = "TestValue798284748",
                ServerAuthCode = "TestValue975282382"
            };

            // Act
            var result = await _testClass.Google(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallApple()
        {
            // Arrange
            var dto = new AppleLogInDto
            {
                Name = "TestValue153713647",
                Email = "TestValue2099106318",
                AppleId = "TestValue738158361",
                AppleIdCode = "TestValue1041143253"
            };

            // Act
            var result = await _testClass.Apple(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallRefreshToken()
        {
            // Arrange
            var dto = new RefreshTokenDto
            {
                RefreshToken = "TestValue993160001",
                AccessToken = "TestValue1165214389"
            };

            // Act
            var result = await _testClass.RefreshToken(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallRegistration()
        {
            // Arrange
            var dto = new RegistrationDto
            {
                UserName = "TestValue276288873",
                Email = "TestValue536226013",
                Password = "TestValue103660965",
                ConfirmPassword = "TestValue2030282071"
            };

            // Act
            var result = await _testClass.Registration(dto);

            // Assert
            _mediator.Received(1);
        }
    }
}