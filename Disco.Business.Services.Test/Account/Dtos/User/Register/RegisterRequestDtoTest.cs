using Disco.Business.Interfaces.Dtos.Account.User.Register;

namespace Disco.Business.Services.Test.Account.Dtos.User.Register
{
    [TestFixture]
    public class RefreshTokenResponseDtoTests
    {
        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            string userName = "test";
            string email = "test@gmail.com";
            string password = "Test2023!";
            string confirmationPassword = "Test2023!";

            // Act
            var registerResponseDto = new RegisterRequestDto(userName, email, password, confirmationPassword);

            // Assert
            Assert.AreEqual(userName, registerResponseDto.UserName);
            Assert.AreEqual(email, registerResponseDto.Email);
            Assert.AreEqual(password, registerResponseDto.Password);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var userName = "test";
            string email = "email@email.com";
            string password = "12345!";
            string confirmPassword = password;

            var registerResponseDto = new RegisterRequestDto("test", "email@email.com", "12345!", "12345!");

            // Assert
            Assert.AreEqual(email, registerResponseDto.Email);
            Assert.AreEqual(userName, registerResponseDto.UserName);
            Assert.AreEqual(password, registerResponseDto.Password);
            Assert.AreEqual(confirmPassword, registerResponseDto.ConfirmPassword);
        }
    }
}
