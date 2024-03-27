using Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Test.Account.Dtos.Admin.RefreshToken
{
    [TestFixture]
    public class RefreshTokenResponseDtoTest
    {
        [Test]
        public void DefaultConstructor_PropertiesAreNotNull()
        {
            // Arrange
            RefreshTokenResponseDto refreshTokenResponse = new RefreshTokenResponseDto();
            refreshTokenResponse.User = new UserDto(1, "test", "test@test.com", new AccountDto("photo", "cread"));
            refreshTokenResponse.AccessToken = "test_token";
            refreshTokenResponse.RefreshToken = "refresh_test";

            // Assert
            Assert.IsNotNull(refreshTokenResponse.User);
            Assert.IsNotNull(refreshTokenResponse.AccessToken);
            Assert.IsNotNull(refreshTokenResponse.RefreshToken);
        }

        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            UserDto user = new UserDto(1, "test", "test@test.com", new AccountDto("photo", "cred"));
            string accessToken = "testAccessToken";
            string refreshToken = "testRefreshToken";

            // Act
            RefreshTokenResponseDto refreshTokenResponse = new RefreshTokenResponseDto(user, accessToken, refreshToken);

            // Assert
            Assert.AreEqual(user, refreshTokenResponse.User);
            Assert.AreEqual(accessToken, refreshTokenResponse.AccessToken);
            Assert.AreEqual(refreshToken, refreshTokenResponse.RefreshToken);
        }

        [Test]
        public void User_SetAndGetProperties_AreEqual()
        {
            // Arrange
            RefreshTokenResponseDto refreshTokenResponse = new RefreshTokenResponseDto();

            // Act
            UserDto newUser = new UserDto(1, "newTest", "newTest@test.com", new AccountDto("newPhoto", "newCred"));
            refreshTokenResponse.User = newUser;

            // Assert
            Assert.AreEqual(newUser, refreshTokenResponse.User);
        }

        [Test]
        public void AccessToken_SetAndGetProperties_AreEqual()
        {
            // Arrange
            RefreshTokenResponseDto refreshTokenResponse = new RefreshTokenResponseDto();

            // Act
            string newAccessToken = "newTestAccessToken";
            refreshTokenResponse.AccessToken = newAccessToken;

            // Assert
            Assert.AreEqual(newAccessToken, refreshTokenResponse.AccessToken);
        }

        [Test]
        public void RefreshToken_SetAndGetProperties_AreEqual()
        {
            // Arrange
            RefreshTokenResponseDto refreshTokenResponse = new RefreshTokenResponseDto();

            // Act
            string newRefreshToken = "newTestRefreshToken";
            refreshTokenResponse.RefreshToken = newRefreshToken;

            // Assert
            Assert.AreEqual(newRefreshToken, refreshTokenResponse.RefreshToken);
        }
    }
}
