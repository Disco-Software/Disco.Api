using Disco.Business.Interfaces.Dtos.Account.User.LogIn;

namespace Disco.Business.Services.Test.Account.Dtos.User.LogIn
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
            var accountDto = new AccountDto("photo.jpg", "abcd1234");

            // Act
            var userDto = new UserDto(id, userName, email, accountDto);

            // Assert
            Assert.AreEqual(id, userDto.Id);
            Assert.AreEqual(userName, userDto.UserName);
            Assert.AreEqual(email, userDto.Email);
            Assert.AreEqual(accountDto, userDto.Account);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("photo.jpg", "abcd1234"));

            // Assert
            Assert.AreEqual(1, userDto.Id);
            Assert.AreEqual("testuser", userDto.UserName);
            Assert.AreEqual("test@example.com", userDto.Email);
            Assert.AreEqual("photo.jpg", userDto.Account.Photo);
            Assert.AreEqual("abcd1234", userDto.Account.Cread);
        }
    }
}
