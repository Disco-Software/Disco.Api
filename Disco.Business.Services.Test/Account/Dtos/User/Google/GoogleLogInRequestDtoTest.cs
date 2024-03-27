using Disco.Business.Interfaces.Dtos.Account.User.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Test.Account.Dtos.User.Google
{
    [TestFixture]
    public class GoogleLogInRequestDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            string email = "test@example.com";
            string userName = "testuser";
            string photo = "test.jpg";
            string id = "123";
            string idToken = "token";
            string serverAuthCode = "authcode";

            // Act
            var googleLogInRequestDto = new GoogleLogInRequestDto(email, userName, photo, id, idToken, serverAuthCode);

            // Assert
            Assert.AreEqual(email, googleLogInRequestDto.Email);
            Assert.AreEqual(userName, googleLogInRequestDto.UserName);
            Assert.AreEqual(photo, googleLogInRequestDto.Photo);
            Assert.AreEqual(id, googleLogInRequestDto.Id);
            Assert.AreEqual(idToken, googleLogInRequestDto.IdToken);
            Assert.AreEqual(serverAuthCode, googleLogInRequestDto.ServerAuthCode);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var googleLogInRequestDto = new GoogleLogInRequestDto("test@example.com", "testuser", "test.jpg", "123", "token", "authcode");

            // Act
            // You can use the properties to set and get values

            // Assert
            Assert.AreEqual("test@example.com", googleLogInRequestDto.Email);
            Assert.AreEqual("testuser", googleLogInRequestDto.UserName);
            Assert.AreEqual("test.jpg", googleLogInRequestDto.Photo);
            Assert.AreEqual("123", googleLogInRequestDto.Id);
            Assert.AreEqual("token", googleLogInRequestDto.IdToken);
            Assert.AreEqual("authcode", googleLogInRequestDto.ServerAuthCode);
        }
    }
}
