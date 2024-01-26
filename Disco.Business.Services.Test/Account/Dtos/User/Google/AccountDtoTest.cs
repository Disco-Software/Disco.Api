using Disco.Business.Interfaces.Dtos.Account.User.Google;

namespace Disco.Business.Services.Test.Account.Dtos.User.Google
{
    public class AccountDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            string photo = "test.jpg";
            string cread = "123";

            // Act
            var accountDto = new AccountDto(photo, cread);

            // Assert
            Assert.AreEqual(photo, accountDto.Photo);
            Assert.AreEqual(cread, accountDto.Cread);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Arrange
            var accountDto = new AccountDto("test.jpg", "123");

            // Act
            // You can use the properties to set and get values

            // Assert
            Assert.AreEqual("test.jpg", accountDto.Photo);
            Assert.AreEqual("123", accountDto.Cread);
        }
    }
}
