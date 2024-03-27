using Disco.Business.Interfaces.Dtos.Account.User.Apple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Test.Account.Dtos.User.Apple
{
    [TestFixture]
    public class AppleLogInResponseDtoTests
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            UserDto user = new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread"));
            string accessToken = "testAccessToken";
            string refreshToken = "testRefreshToken";

            // Act
            AppleLogInResponseDto appleLogInResponseDto = new AppleLogInResponseDto(user, accessToken, refreshToken);

            // Assert
            Assert.AreEqual(user, appleLogInResponseDto.User);
            Assert.AreEqual(accessToken, appleLogInResponseDto.AccessToken);
            Assert.AreEqual(refreshToken, appleLogInResponseDto.RefreshToken);
        }

        [Test]
        public void User_SetAndGetProperties_AreEqual()
        {
            // Arrange
            AppleLogInResponseDto appleLogInResponseDto = new AppleLogInResponseDto(new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread")), "testAccessToken", "testRefreshToken");

            // Act
            UserDto newUser = new UserDto(2, "newTestUser", "newTest@test.com", new AccountDto("newTestPhoto", "newTestCread"));
            appleLogInResponseDto.User = newUser;

            // Assert
            Assert.AreEqual(newUser, appleLogInResponseDto.User);
        }

        [Test]
        public void AccessToken_SetAndGetProperties_AreEqual()
        {
            // Arrange
            AppleLogInResponseDto appleLogInResponseDto = new AppleLogInResponseDto(new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread")), "testAccessToken", "testRefreshToken");

            // Act
            string newAccessToken = "newTestAccessToken";
            appleLogInResponseDto.AccessToken = newAccessToken;

            // Assert
            Assert.AreEqual(newAccessToken, appleLogInResponseDto.AccessToken);
        }

        [Test]
        public void RefreshToken_SetAndGetProperties_AreEqual()
        {
            // Arrange
            AppleLogInResponseDto appleLogInResponseDto = new AppleLogInResponseDto(new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread")), "testAccessToken", "testRefreshToken");

            // Act
            string newRefreshToken = "newTestRefreshToken";
            appleLogInResponseDto.RefreshToken = newRefreshToken;

            // Assert
            Assert.AreEqual(newRefreshToken, appleLogInResponseDto.RefreshToken);
        }
    }
}
