using Disco.Business.Interfaces.Dtos.Account.User.Google;

namespace Disco.Business.Services.Test.Account.Dtos.User.Google
{
    [TestFixture]
    public class GoogleLogInResponseDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("test.jpg", "123"));
            string accessToken = "access_token";
            string refreshToken = "refresh_token";

            // Act
            var googleResponseDto = new GoogleResponseDto(userDto, accessToken, refreshToken);

            // Assert
            Assert.AreEqual(userDto, googleResponseDto.User);
            Assert.AreEqual(accessToken, googleResponseDto.AccessToken);
            Assert.AreEqual(refreshToken, googleResponseDto.RefreshToken);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("test.jpg", "123"));
            var googleResponseDto = new GoogleResponseDto(userDto, "access_token", "refresh_token");

            // Assert
            Assert.AreEqual(userDto, googleResponseDto.User);
            Assert.AreEqual("access_token", googleResponseDto.AccessToken);
            Assert.AreEqual("refresh_token", googleResponseDto.RefreshToken);
        }
    }
}
