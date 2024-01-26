using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;

namespace Disco.Business.Services.Test.Account.Admin.Dtos.LogIn
{
    [TestFixture]
    public class LogInResponseDtoTest
    {
        [Test]
        public void LogInResponseDto_Initialization_ShouldSetProperties()
        {
            // Arrange
            UserDto expectedUser = new UserDto(1, "Admin", "john_doe", "john.doe@example.com", new AccountDto("photo.jpg", "sampleCread"));
            string expectedAccessToken = "sampleAccessToken";
            string expectedRefreshToken = "sampleRefreshToken";

            // Act
            var logInResponseDto = new LogInResponseDto(expectedUser, expectedAccessToken, expectedRefreshToken);

            // Assert
            Assert.AreEqual(expectedUser, logInResponseDto.User);
            Assert.AreEqual(expectedAccessToken, logInResponseDto.AccessToken);
            Assert.AreEqual(expectedRefreshToken, logInResponseDto.RefreshToken);
        }

        [Test]
        public void LogInResponseDto_User_Setter_ShouldSetUserProperty()
        {
            // Arrange
            var logInResponseDto = new LogInResponseDto();
            UserDto newUser = new UserDto(2, "User", "jane_doe", "jane.doe@example.com", new AccountDto("new_photo.jpg", "newCread"));

            // Act
            logInResponseDto.User = newUser;

            // Assert
            Assert.AreEqual(newUser, logInResponseDto.User);
        }

        [Test]
        public void LogInResponseDto_AccessToken_Setter_ShouldSetAccessTokenProperty()
        {
            // Arrange
            var logInResponseDto = new LogInResponseDto();
            string newAccessToken = "newAccessToken";

            // Act
            logInResponseDto.AccessToken = newAccessToken;

            // Assert
            Assert.AreEqual(newAccessToken, logInResponseDto.AccessToken);
        }

        [Test]
        public void LogInResponseDto_RefreshToken_Setter_ShouldSetRefreshTokenProperty()
        {
            // Arrange
            var logInResponseDto = new LogInResponseDto();
            string newRefreshToken = "newRefreshToken";

            // Act
            logInResponseDto.RefreshToken = newRefreshToken;

            // Assert
            Assert.AreEqual(newRefreshToken, logInResponseDto.RefreshToken);
        }
    }
}
