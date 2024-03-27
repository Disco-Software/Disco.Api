using Disco.Business.Interfaces.Dtos.Account.User.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Test.Account.Dtos.User.LogIn
{
    [TestFixture]
    public class LogInRequestDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            string email = "test@example.com";
            string password = "password123";

            // Act
            var logInRequestDto = new LogInRequestDto(email, password);

            // Assert
            Assert.AreEqual(email, logInRequestDto.Email);
            Assert.AreEqual(password, logInRequestDto.Password);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var logInRequestDto = new LogInRequestDto("test@example.com", "password123");

            // Act
            // You can use the properties to set and get values

            // Assert
            Assert.AreEqual("test@example.com", logInRequestDto.Email);
            Assert.AreEqual("password123", logInRequestDto.Password);
        }
    }
}
