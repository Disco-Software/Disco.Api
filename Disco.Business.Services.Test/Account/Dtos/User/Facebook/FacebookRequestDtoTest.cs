using Disco.Business.Interfaces.Dtos.Account.User.Facebook;

namespace Disco.Business.Services.Test.Account.Dtos.User.Facebook
{
    [TestFixture]
    public class FacebookRequestDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            string facebookAccessToken = "testFacebookAccessToken";

            // Act
            FacebookRequestDto facebookRequestDto = new FacebookRequestDto(facebookAccessToken);

            // Assert
            Assert.AreEqual(facebookAccessToken, facebookRequestDto.FacebookAccessToken);
        }

        [Test]
        public void FacebookAccessToken_SetAndGetProperties_AreEqual()
        {
            // Arrange
            FacebookRequestDto facebookRequestDto = new FacebookRequestDto("testFacebookAccessToken");

            // Act
            string newFacebookAccessToken = "newTestFacebookAccessToken";
            facebookRequestDto.FacebookAccessToken = newFacebookAccessToken;

            // Assert
            Assert.AreEqual(newFacebookAccessToken, facebookRequestDto.FacebookAccessToken);
        }
    }
}
