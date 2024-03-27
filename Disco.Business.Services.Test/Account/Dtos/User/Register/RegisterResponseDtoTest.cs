using Disco.Business.Interfaces.Dtos.Account.User.Register;

namespace Disco.Business.Services.Test.Account.Dtos.User.Register
{
    [TestFixture]
    public class RegisterResponseDtoTest
    {
        [Test]
        public void ParameterlessConstructor_InitializesProperties()
        {
            // Arrange & Act
            var registerResponseDto = new RegisterResponseDto();

            // Assert
            Assert.IsNull(registerResponseDto.User);
            Assert.IsNull(registerResponseDto.AccessToken);
            Assert.IsNull(registerResponseDto.RefreshToken);
        }

        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("photo123", "cred456"));
            string accessToken = "access123";
            string refreshToken = "refresh456";

            // Act
            var registerResponseDto = new RegisterResponseDto(userDto, accessToken, refreshToken);

            // Assert
            Assert.AreEqual(userDto, registerResponseDto.User);
            Assert.AreEqual(accessToken, registerResponseDto.AccessToken);
            Assert.AreEqual(refreshToken, registerResponseDto.RefreshToken);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("photo123", "cred456"));
            var registerResponseDto = new RegisterResponseDto();

            // Act
            registerResponseDto.User = userDto;
            registerResponseDto.AccessToken = "access123";
            registerResponseDto.RefreshToken = "refresh456";

            // Assert
            Assert.AreEqual(userDto, registerResponseDto.User);
            Assert.AreEqual("access123", registerResponseDto.AccessToken);
            Assert.AreEqual("refresh456", registerResponseDto.RefreshToken);
        }
    }
}
