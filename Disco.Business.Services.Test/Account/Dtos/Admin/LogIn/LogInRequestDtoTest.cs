using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;

namespace Disco.Business.Services.Test.Account.Admin.Dtos.LogIn
{
    [TestFixture]
    public class LogInRequestDtoTest
    {
        [Test]
        public void LogInRequestDto_Initialization_ShouldSetProperties()
        {
            // Arrange
            string expectedEmail = "test@example.com";
            string expectedPassword = "password";

            // Act
            var logInRequestDto = new LogInRequestDto(expectedEmail, expectedPassword);

            // Assert
            Assert.AreEqual(expectedEmail, logInRequestDto.Email);
            Assert.AreEqual(expectedPassword, logInRequestDto.Password);
        }

        [Test]
        public void LogInRequestDto_Email_Setter_ShouldSetEmailProperty()
        {
            // Arrange
            var logInRequestDto = new LogInRequestDto("old@example.com", "oldPassword");
            string newEmail = "new@example.com";

            // Act
            logInRequestDto.Email = newEmail;

            // Assert
            Assert.AreEqual(newEmail, logInRequestDto.Email);
        }

        [Test]
        public void LogInRequestDto_Password_Setter_ShouldSetPasswordProperty()
        {
            // Arrange
            var logInRequestDto = new LogInRequestDto("test@example.com", "oldPassword");
            string newPassword = "newPassword";

            // Act
            logInRequestDto.Password = newPassword;

            // Assert
            Assert.AreEqual(newPassword, logInRequestDto.Password);
        }
    }
}
