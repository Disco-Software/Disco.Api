using Disco.Business.Interfaces.Dtos.Account.User.Apple;

namespace Disco.Business.Services.Test.Account.Dtos.User.Apple
{
    [TestFixture]
    public class UserDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            int id = 1;
            string userName = "testUser";
            string email = "test@test.com";
            AccountDto account = new AccountDto("testPhoto", "testCread");

            // Act
            UserDto userDto = new UserDto(id, userName, email, account);

            // Assert
            Assert.AreEqual(id, userDto.Id);
            Assert.AreEqual(userName, userDto.UserName);
            Assert.AreEqual(email, userDto.Email);
            Assert.AreEqual(account, userDto.Account);
        }

        [Test]
        public void Id_SetAndGetProperties_AreEqual()
        {
            // Arrange
            UserDto userDto = new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread"));

            // Act
            int newId = 2;
            userDto.Id = newId;

            // Assert
            Assert.AreEqual(newId, userDto.Id);
        }

        [Test]
        public void UserName_SetAndGetProperties_AreEqual()
        {
            // Arrange
            UserDto userDto = new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread"));

            // Act
            string newUserName = "newTestUser";
            userDto.UserName = newUserName;

            // Assert
            Assert.AreEqual(newUserName, userDto.UserName);
        }

        [Test]
        public void Email_SetAndGetProperties_AreEqual()
        {
            // Arrange
            UserDto userDto = new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread"));

            // Act
            string newEmail = "newTest@test.com";
            userDto.Email = newEmail;

            // Assert
            Assert.AreEqual(newEmail, userDto.Email);
        }

        [Test]
        public void Account_SetAndGetProperties_AreEqual()
        {
            // Arrange
            UserDto userDto = new UserDto(1, "testUser", "test@test.com", new AccountDto("testPhoto", "testCread"));

            // Act
            AccountDto newAccount = new AccountDto("newPhoto", "newCread");
            userDto.Account = newAccount;

            // Assert
            Assert.AreEqual(newAccount, userDto.Account);
        }
    }
}
