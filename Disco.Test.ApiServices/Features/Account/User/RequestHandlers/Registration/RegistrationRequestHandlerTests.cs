namespace Disco.Test.Business.Features.Account.User.RequestHandlers.Registration
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.Registration;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Business.Services.Mappers;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class RegistrationRequestHandlerTests
    {
        private RegistrationRequestHandler _testClass;
        private Mock<IAccountService> _accountService;
        private Mock<IAccountPasswordService> _accountPasswordService;
        private Mock<ITokenService> _tokenService;
        
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = new Mock<IAccountService>();
            _accountPasswordService = new Mock<IAccountPasswordService>();
            _tokenService = new Mock<ITokenService>();
            
            _mapper = new MapperConfiguration(x => x.AddProfile(new AccountMapProfile())).CreateMapper();
            
            _testClass = new RegistrationRequestHandler(_accountService.Object, _accountPasswordService.Object, _tokenService.Object, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RegistrationRequestHandler(_accountService.Object, _accountPasswordService.Object, _tokenService.Object, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new RegistrationRequest(new RegistrationDto
            {
                UserName = "TestValue184778014",
                Email = "TestValue1700170026",
                Password = "TestValue686651199",
                ConfirmPassword = "TestValue1222039319"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.Setup(mock => mock.CreateAsync(It.IsAny<User>())).Verifiable();
            _accountService.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();
            _accountPasswordService.Setup(mock => mock.AddPasswod(It.IsAny<User>(), It.IsAny<string>())).Returns("TestValue1725882267");
            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue1329312135");
            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue825462623");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            _accountService.Verify(mock => mock.CreateAsync(It.IsAny<User>()));
            _accountService.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()));
            _accountPasswordService.Verify(mock => mock.AddPasswod(It.IsAny<User>(), It.IsAny<string>()));
            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
            _tokenService.Verify(mock => mock.GenerateRefreshToken());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(RegistrationRequest), CancellationToken.None));
        }
    }
}