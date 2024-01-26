using Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken;

namespace Disco.Business.Services.Test.Account.Dtos.Admin.RefreshToken
{
    [TestFixture]
    public class UserDtoTest
    {
        public UserDto model;

        [SetUp]
        public void SetUp()
        {
            model = new UserDto(1, "Test", "test@test.com", new AccountDto("photo", "cread"));
        }

        [Test]
        public void Constructor_Initialize_ReturnsNewInstance()
        {
            //Act
            model = new UserDto(1, "Test", "test@test.com", new AccountDto("photo", "cread"));

            //Assert
            Assert.That(model, Is.Not.Null);
        }

        [Test]
        public void Constructor_WithValidParameters_SetsPropertiesCorrectly()
        {
            // Arrange
            int id = 1;
            string userName = "testuser";
            string email = "test@example.com";
            var accountDto = new AccountDto("sample_photo", "sample_cread");

            // Act
            var userDto = new UserDto(id, userName, email, accountDto);

            // Assert
            Assert.AreEqual(id, userDto.Id);
            Assert.AreEqual(userName, userDto.UserName);
            Assert.AreEqual(email, userDto.Email);
            Assert.AreSame(accountDto, userDto.Account);
        }

        [Test]
        public void Constructor_ZeroId_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new UserDto(0, "test", "test@test.com", new AccountDto("photo", "cread")));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Constructor_NullOrEmptyOrWhiteSpaceUserName_ThrowsArgumentNullException(string userName)
        {
            Assert.Throws<ArgumentNullException>(() => new UserDto(1, userName, "test@test.com", new AccountDto("photo", "cread")));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Constructor_NullOrEmptyOrWhiteSpaceEmail_ThrowsArgumentNullException(string email)
        {
            Assert.Throws<ArgumentNullException>(() => new UserDto(1, email, "test@test.com", new AccountDto("photo", "cread")));
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var userDto = new UserDto(1, "testuser", "test@example.com", new AccountDto("photo1", "cread1"));

            // Act
            userDto.Id = 2;
            userDto.UserName = "newuser";
            userDto.Email = "new@example.com";
            userDto.Account = new AccountDto("photo2", "cread2");

            // Assert
            Assert.AreEqual(2, userDto.Id);
            Assert.AreEqual("newuser", userDto.UserName);
            Assert.AreEqual("new@example.com", userDto.Email);
            Assert.AreEqual("photo2", userDto.Account.Photo);
            Assert.AreEqual("cread2", userDto.Account.Cread);
        }
    }
}
