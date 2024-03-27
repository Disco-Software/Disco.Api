using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;

namespace Disco.Business.Services.Test.Account.Admin.Dtos.LogIn
{
    public class UserDtoTest
    {
        public UserDto model { get; set; }

        public UserDtoTest()
        {
            model = new UserDto(1, "admin", "test", "test@gmail.com", new AccountDto("photo.png", "cread"));
        }


        [Test]
        public void UserDto_Initialization_ShouldSetProperties()
        {
            // Arrange
            int expectedId = 1;
            string expectedRoleName = "Admin";
            string expectedUserName = "john_doe";
            string expectedEmail = "john.doe@example.com";
            AccountDto expectedAccount = new AccountDto("photo.jpg", "sampleCread");

            // Act
            var userDto = new UserDto(expectedId, expectedRoleName, expectedUserName, expectedEmail, expectedAccount);

            // Assert
            Assert.AreEqual(expectedId, userDto.Id);
            Assert.AreEqual(expectedRoleName, userDto.RoleName);
            Assert.AreEqual(expectedUserName, userDto.UserName);
            Assert.AreEqual(expectedEmail, userDto.Email);
            Assert.AreEqual(expectedAccount, userDto.Account);
        }

        [Test]
        public void UserDto_Id_Setter_ShouldSetIdProperty()
        {
            // Arrange
            var userDto = new UserDto(1, "Admin", "john_doe", "john.doe@example.com", new AccountDto("photo.jpg", "sampleCread"));
            int newId = 2;

            // Act
            userDto.Id = newId;

            // Assert
            Assert.AreEqual(newId, userDto.Id);
        }

        [Test]
        public void UserDto_RoleName_Setter_ShouldSetRoleNameProperty()
        {
            // Arrange
            var userDto = new UserDto(1, "Admin", "john_doe", "john.doe@example.com", new AccountDto("photo.jpg", "sampleCread"));
            string newRoleName = "User";

            // Act
            userDto.RoleName = newRoleName;

            // Assert
            Assert.AreEqual(newRoleName, userDto.RoleName);
        }

        [Test]
        public void UserDto_UserName_Setter_ShouldSetUserNameProperty()
        {
            // Arrange
            var userDto = new UserDto(1, "Admin", "john_doe", "john.doe@example.com", new AccountDto("photo.jpg", "sampleCread"));
            string newUserName = "jane_doe";

            // Act
            userDto.UserName = newUserName;

            // Assert
            Assert.AreEqual(newUserName, userDto.UserName);
        }

        [Test]
        public void UserDto_Email_Setter_ShouldSetEmailProperty()
        {
            // Arrange
            var userDto = new UserDto(1, "Admin", "john_doe", "john.doe@example.com", new AccountDto("photo.jpg", "sampleCread"));
            string newEmail = "jane.doe@example.com";

            // Act
            userDto.Email = newEmail;

            // Assert
            Assert.AreEqual(newEmail, userDto.Email);
        }

        [Test]
        public void UserDto_Account_Setter_ShouldSetAccountProperty()
        {
            // Arrange
            var userDto = new UserDto(1, "Admin", "john_doe", "john.doe@example.com", new AccountDto("photo.jpg", "sampleCread"));
            AccountDto newAccount = new AccountDto("new_photo.jpg", "newCread");

            // Act
            userDto.Account = newAccount;

            // Assert
            Assert.AreEqual(newAccount, userDto.Account);
        }

    }
}
