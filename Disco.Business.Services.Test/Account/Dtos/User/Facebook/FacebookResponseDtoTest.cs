using Disco.Business.Interfaces.Dtos.Account.User.Facebook;

namespace Disco.Business.Services.Test.Account.Dtos.User.Facebook
{
    [TestFixture]
    public class FacebookResponseDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            UserDto user = new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread"));
            string accessToken = "testAccessToken";
            string refreshToken = "testRefreshToken";

            // Act
            FacebookResponseDto facebookResponseDto = new FacebookResponseDto(user, accessToken, refreshToken);

            // Assert
            Assert.AreEqual(user, facebookResponseDto.User);
            Assert.AreEqual(accessToken, facebookResponseDto.AccessToken);
            Assert.AreEqual(refreshToken, facebookResponseDto.RefreshToken);
        }

        [Test]
        public void User_SetAndGetProperties_AreEqual()
        {
            // Arrange
            FacebookResponseDto facebookResponseDto = new FacebookResponseDto(new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread")), "testAccessToken", "testRefreshToken");

            // Act
            UserDto newUser = new UserDto(2, "newTestUser", "newTest@test.com", new AccountDto("newTestPhoto", "newTestCread"));
            facebookResponseDto.User = newUser;

            // Assert
            Assert.AreEqual(newUser, facebookResponseDto.User);
        }

        [Test]
        public void AccessToken_SetAndGetProperties_AreEqual()
        {
            // Arrange
            FacebookResponseDto facebookResponseDto = new FacebookResponseDto(new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread")), "testAccessToken", "testRefreshToken");

            // Act
            string newAccessToken = "newTestAccessToken";
            facebookResponseDto.AccessToken = newAccessToken;

            // Assert
            Assert.AreEqual(newAccessToken, facebookResponseDto.AccessToken);
        }

        [Test]
        public void RefreshToken_SetAndGetProperties_AreEqual()
        {
            // Arrange
            FacebookResponseDto facebookResponseDto = new FacebookResponseDto(new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread")), "testAccessToken", "testRefreshToken");

            // Act
            string newRefreshToken = "newTestRefreshToken";
            facebookResponseDto.RefreshToken = newRefreshToken;

            // Assert
            Assert.AreEqual(newRefreshToken, facebookResponseDto.RefreshToken);
        }
    }
}
