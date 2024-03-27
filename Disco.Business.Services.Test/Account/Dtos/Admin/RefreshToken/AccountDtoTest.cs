using Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken;

namespace Disco.Business.Services.Test.Account.Dtos.Admin.RefreshToken
{
    [TestFixture]
    public class AccountDtoTest
    {
        public AccountDto model;

        [SetUp] 
        public void SetUp()
        {
            model = new AccountDto("test_photo", "test_cread");
        }

        [Test]
        public void Constructor_WithValidParameters_SetsPropertiesCorrectly()
        {
            // Arrange
            string photo = "sample_photo";
            string cread = "sample_cread";

            // Act
            var accountDto = new AccountDto(photo, cread);

            // Assert
            Assert.AreEqual(photo, accountDto.Photo);
            Assert.AreEqual(cread, accountDto.Cread);
        }

        [Test]
        public void Properties_SetAndGetCorrectly()
        {
            // Act
            model.Photo = "new_photo";
            model.Cread = "new_cread";

            // Assert
            Assert.AreEqual("new_photo", model.Photo);
            Assert.AreEqual("new_cread", model.Cread);
        }
    }
}
