using Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken;

namespace Disco.Business.Services.Test.Account.Dtos.Admin.RefreshToken
{
    [TestFixture]
    public class RefreshTokenRequestDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            string accessToken = "testAccessToken";
            string refreshToken = "testRefreshToken";

            // Act
            RefreshTokenRequestDto refreshTokenRequest = new RefreshTokenRequestDto(accessToken, refreshToken);

            // Assert
            Assert.AreEqual(accessToken, refreshTokenRequest.AccessToken);
            Assert.AreEqual(refreshToken, refreshTokenRequest.RefreshToken);
        }

        [Test]
        public void AccessToken_SetAndGetProperties_AreEqual()
        {
            // Arrange
            RefreshTokenRequestDto refreshTokenRequest = new RefreshTokenRequestDto("testAccessToken", "testRefreshToken");

            // Act
            string newAccessToken = "newTestAccessToken";
            refreshTokenRequest.AccessToken = newAccessToken;

            // Assert
            Assert.AreEqual(newAccessToken, refreshTokenRequest.AccessToken);
        }

        [Test]
        public void RefreshToken_SetAndGetProperties_AreEqual()
        {
            // Arrange
            RefreshTokenRequestDto refreshTokenRequest = new RefreshTokenRequestDto("testAccessToken", "testRefreshToken");

            // Act
            string newRefreshToken = "newTestRefreshToken";
            refreshTokenRequest.RefreshToken = newRefreshToken;

            // Assert
            Assert.AreEqual(newRefreshToken, refreshTokenRequest.RefreshToken);
        }
    }
}
