using AutoMapper;
using Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Services.Mapper.Account.Admin;
using Disco.Business.Utils.Exceptions;
using Disco.Domain.Models.Models;
using Moq;

namespace Disco.ApiServices.Test.Features.Account.Admin.RequestHandlers.LogIn
{
    [TestFixture]
    public class LogInRequestHandlerTest
    {
        private LogInRequestHandler _handler;

        private Mock<IAccountService> _accountServiceMock;
        private Mock<IAccountPasswordService> _accountPasswordServiceMock;
        private Mock<ITokenService> _tokenServiceMock;

        [SetUp]
        public void SetUp()
        {
            var mapper = new MapperConfiguration(x =>
                x.AddProfile(new LogInMappingProfile())).CreateMapper();

            _accountServiceMock = new Mock<IAccountService>();
            _accountPasswordServiceMock = new Mock<IAccountPasswordService>();
            _tokenServiceMock = new Mock<ITokenService>();

            _handler = new LogInRequestHandler(
                _accountServiceMock.Object,
                _accountPasswordServiceMock.Object,
                _tokenServiceMock.Object,
                mapper);
        }

        [Test]
        public void Constructor_WhenValidParams_ReturnsSuccessInitialize()
        {
            //Arrange
            var mapper = new MapperConfiguration(x =>
                x.AddProfile(new LogInMappingProfile())).CreateMapper();

            //Act
            _handler = new LogInRequestHandler(
                _accountServiceMock.Object,
                _accountPasswordServiceMock.Object,
                _tokenServiceMock.Object,
                mapper);

            //Assert
            Assert.That(_handler, Is.Not.Null);
        }

        [Test]
        public async Task Handle_WhenLogInRequestIsValid_ReturnsLogInResponseDto()
        {
            //Arrange
            var user = new User { AccessFailedCount = 1, UserName = "TestName", NormalizedUserName = "TESTNAME", Email = "test@disco.net.ua", RoleName = "Admin", Account = new Domain.Models.Models.Account() };

            _accountServiceMock.Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(user);
            _accountServiceMock.Setup(x => x.IsInRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(true);
            _accountPasswordServiceMock.Setup(x => x.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success);
            _tokenServiceMock.Setup(x => x.GenerateAccessToken(user))
                .Returns(Guid.NewGuid().ToString());
            _tokenServiceMock.Setup(x => x.GenerateRefreshToken())
                .Returns(Guid.NewGuid().ToString());

            //Act
            var result = await _handler.Handle(new LogInRequest(
                new Business.Interfaces.Dtos.Account.Admin.LogIn.LogInRequestDto("test@gmail.com", "Test2024!")),
                CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);

            _accountServiceMock.Verify(x => x.GetByEmailAsync(It.IsAny<string>()));
            _accountServiceMock.Verify(x => x.IsInRoleAsync(It.IsAny<User>(), It.IsAny<string>()));
            _accountPasswordServiceMock.Verify(x => x.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>()));
            _tokenServiceMock.Verify(x => x.GenerateAccessToken(It.IsAny<User>()));
            _tokenServiceMock.Verify(x => x.GenerateRefreshToken());
        }

        [Test]
        public void Handle_WhenPasswordIsInvalid_ThrowsInvalidPasswordException()
        {
            //Assert
            Assert.ThrowsAsync<InvalidPasswordException>(async () =>
            {
                var user = new User
                {
                    RoleName = "User",
                    UserName = Guid.NewGuid().ToString(),
                    Email = Guid.NewGuid().ToString(),
                    NormalizedUserName = Guid.NewGuid().ToString(),
                    NormalizedEmail = Guid.NewGuid().ToString(),
                    Account = new Domain.Models.Models.Account()
                };

                _accountPasswordServiceMock.Setup(x => x.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                    .ReturnsAsync(Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed);

                //Act
                await _handler.Handle(
                    new LogInRequest(new Business.Interfaces.Dtos.Account.Admin.LogIn.LogInRequestDto(
                        It.IsAny<string>(),
                        It.IsAny<string>())),
                    CancellationToken.None);
            });
        }

        [Test]
        public void Handle_WhenRoleIsUser_ThrowsInvalidRoleException()
        {
            //Assert
            Assert.ThrowsAsync<InvalidRoleException>(async () =>
            {
                var user = new User
                {
                    RoleName = "User",
                    UserName = Guid.NewGuid().ToString(),
                    Email = Guid.NewGuid().ToString(),
                    NormalizedUserName = Guid.NewGuid().ToString(),
                    NormalizedEmail = Guid.NewGuid().ToString(),
                    Account = new Domain.Models.Models.Account()
                };

                _accountPasswordServiceMock.Setup(x => x.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                    .ReturnsAsync(Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success);
                _accountServiceMock.Setup(x => x.IsInRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                    .ReturnsAsync(false);

                //Act
                await _handler.Handle(
                    new LogInRequest(new Business.Interfaces.Dtos.Account.Admin.LogIn.LogInRequestDto(
                        It.IsAny<string>(), 
                        It.IsAny<string>())),
                    CancellationToken.None);
            });
        }
    }
}
