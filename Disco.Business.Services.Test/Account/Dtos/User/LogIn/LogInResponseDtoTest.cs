using Disco.Business.Interfaces.Dtos.Account.User.LogIn;

namespace Disco.Business.Services.Test.Account.Dtos.User.LogIn
{
    public class LogInResponseDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("photo.jpg", "abcd1234"));
            string accessToken = "access_token";
            string refreshToken = "refresh_token";

            // Act
            var logInResponseDto = new LogInResponseDto(userDto, accessToken, refreshToken);

            // Assert
            Assert.AreEqual(userDto, logInResponseDto.User);
            Assert.AreEqual(accessToken, logInResponseDto.AccessToken);
            Assert.AreEqual(refreshToken, logInResponseDto.RefreshToken);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("photo.jpg", "abcd1234"));
            var logInResponseDto = new LogInResponseDto(userDto, "access_token", "refresh_token");

            // Assert
            Assert.AreEqual(userDto, logInResponseDto.User);
            Assert.AreEqual("access_token", logInResponseDto.AccessToken);
            Assert.AreEqual("refresh_token", logInResponseDto.RefreshToken);
        }
    }
}
