using Disco.Business.Interfaces.Dtos.Account.User.Facebook;

namespace Disco.Business.Services.Test.Account.Dtos.User.Facebook
{
    [TestFixture]
    public class AccountDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            string photo = "testPhoto";
            string cread = "testCread";

            // Act
            AccountDto accountDto = new AccountDto(photo, cread);

            // Assert
            Assert.AreEqual(photo, accountDto.Photo);
            Assert.AreEqual(cread, accountDto.Cread);
        }

        [Test]
        public void Photo_SetAndGetProperties_AreEqual()
        {
            // Arrange
            AccountDto accountDto = new AccountDto("testPhoto", "testCread");

            // Act
            string newPhoto = "newTestPhoto";
            accountDto.Photo = newPhoto;

            // Assert
            Assert.AreEqual(newPhoto, accountDto.Photo);
        }

        [Test]
        public void Cread_SetAndGetProperties_AreEqual()
        {
            // Arrange
            AccountDto accountDto = new AccountDto("testPhoto", "testCread");

            // Act
            string newCread = "newTestCread";
            accountDto.Cread = newCread;

            // Assert
            Assert.AreEqual(newCread, accountDto.Cread);
        }
    }
}
