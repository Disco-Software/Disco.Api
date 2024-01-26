using Disco.Business.Interfaces.Dtos.Account.User.RefreshToken;

namespace Disco.Business.Services.Test.Account.Dtos.User.RefreshToken
{
    [TestFixture]
    public class RefreshTokenRequestDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            string refreshToken = "refresh123";
            string accessToken = "access456";

            // Act
            var refreshTokenRequestDto = new RefreshTokenRequestDto(refreshToken, accessToken);

            // Assert
            Assert.AreEqual(refreshToken, refreshTokenRequestDto.RefreshToken);
            Assert.AreEqual(accessToken, refreshTokenRequestDto.AccessToken);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var refreshTokenRequestDto = new RefreshTokenRequestDto("refresh123", "access456");

            // Act
            // You can use the properties to set and get values

            // Assert
            Assert.AreEqual("refresh123", refreshTokenRequestDto.RefreshToken);
            Assert.AreEqual("access456", refreshTokenRequestDto.AccessToken);
        }
    }
}
