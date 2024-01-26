using Disco.Business.Interfaces.Dtos.Account.User.Register;

namespace Disco.Business.Services.Test.Account.Dtos.User.Register
{
    [TestFixture]
    public class UserDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            int id = 1;
            string userName = "testuser";
            string email = "test@example.com";
            var account = new AccountDto("photo123", "cred456");

            // Act
            var userDto = new UserDto(id, userName, email, account);

            // Assert
            Assert.AreEqual(id, userDto.Id);
            Assert.AreEqual(userName, userDto.UserName);
            Assert.AreEqual(email, userDto.Email);
            Assert.AreEqual(account, userDto.Account);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("photo123", "cred456"));

            // Assert
            Assert.AreEqual(1, userDto.Id);
            Assert.AreEqual("testuser", userDto.UserName);
            Assert.AreEqual("test@example.com", userDto.Email);
            Assert.IsInstanceOf(typeof(AccountDto), userDto.Account);
        }
    }
}
