using Disco.Business.Interfaces.Dtos.Account.User.RefreshToken;

namespace Disco.Business.Services.Test.Account.Dtos.User.RefreshToken
{
    [TestFixture]
    public class RefreshTokenResponseDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("photo123", "cred456"));
            string refreshToken = "refresh123";
            string accessToken = "access456";

            // Act
            var refreshTokenResponseDto = new RefreshTokenResponseDto(userDto, refreshToken, accessToken);

            // Assert
            Assert.AreEqual(userDto, refreshTokenResponseDto.User);
            Assert.AreEqual(refreshToken, refreshTokenResponseDto.RefreshToken);
            Assert.AreEqual(accessToken, refreshTokenResponseDto.AccessToken);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("photo123", "cred456"));
            var refreshTokenResponseDto = new RefreshTokenResponseDto(userDto, "refresh123", "access456");

            // Assert
            Assert.AreEqual(userDto, refreshTokenResponseDto.User);
            Assert.AreEqual("refresh123", refreshTokenResponseDto.RefreshToken);
            Assert.AreEqual("access456", refreshTokenResponseDto.AccessToken);
        }
    }
}
