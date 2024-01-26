using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;

namespace Disco.Business.Services.Test.Account.Admin.Dtos.LogIn
{
    public class AccountDtoTest
    {
        [Test]
        public void AccountDto_Initialization_ShouldSetProperties()
        {
            // Arrange
            string expectedPhoto = "photo.jpg";
            string expectedCread = "sampleCread";

            // Act
            var accountDto = new AccountDto(expectedPhoto, expectedCread);

            // Assert
            Assert.AreEqual(expectedPhoto, accountDto.Photo);
            Assert.AreEqual(expectedCread, accountDto.Cread);
        }

        [Test]
        public void AccountDto_Photo_Setter_ShouldSetPhotoProperty()
        {
            // Arrange
            var accountDto = new AccountDto("oldPhoto.jpg", "oldCread");
            string newPhoto = "newPhoto.jpg";

            // Act
            accountDto.Photo = newPhoto;

            // Assert
            Assert.AreEqual(newPhoto, accountDto.Photo);
        }

        [Test]
        public void AccountDto_Cread_Setter_ShouldSetCreadProperty()
        {
            // Arrange
            var accountDto = new AccountDto("samplePhoto.jpg", "oldCread");
            string newCread = "newCread";

            // Act
            accountDto.Cread = newCread;

            // Assert
            Assert.AreEqual(newCread, accountDto.Cread);
        }
    }
}
