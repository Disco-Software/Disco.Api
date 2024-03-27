using Disco.Business.Interfaces.Dtos.Account.User.Apple;

namespace Disco.Business.Services.Test.Account.Dtos.User.Apple
{
    [TestFixture]
    public class AppleLogInRequestDtoTest
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            string name = "John Appleseed";
            string email = "john.appleseed@example.com";
            string appleId = "testAppleId";
            string appleIdCode = "testAppleIdCode";

            // Act
            AppleLogInRequestDto appleLogInRequestDto = new AppleLogInRequestDto(name, email, appleId, appleIdCode);

            // Assert
            Assert.AreEqual(name, appleLogInRequestDto.Name);
            Assert.AreEqual(email, appleLogInRequestDto.Email);
            Assert.AreEqual(appleId, appleLogInRequestDto.AppleId);
            Assert.AreEqual(appleIdCode, appleLogInRequestDto.AppleIdCode);
        }

        [Test]
        public void Name_SetAndGetProperties_AreEqual()
        {
            // Arrange
            AppleLogInRequestDto appleLogInRequestDto = new AppleLogInRequestDto("John Appleseed", "john.appleseed@example.com", "testAppleId", "testAppleIdCode");

            // Act
            string newName = "Jane Appleseed";
            appleLogInRequestDto.Name = newName;

            // Assert
            Assert.AreEqual(newName, appleLogInRequestDto.Name);
        }

        [Test]
        public void Email_SetAndGetProperties_AreEqual()
        {
            // Arrange
            AppleLogInRequestDto appleLogInRequestDto = new AppleLogInRequestDto("John Appleseed", "john.appleseed@example.com", "testAppleId", "testAppleIdCode");

            // Act
            string newEmail = "jane.appleseed@example.com";
            appleLogInRequestDto.Email = newEmail;

            // Assert
            Assert.AreEqual(newEmail, appleLogInRequestDto.Email);
        }

        [Test]
        public void AppleId_SetAndGetProperties_AreEqual()
        {
            // Arrange
            AppleLogInRequestDto appleLogInRequestDto = new AppleLogInRequestDto("John Appleseed", "john.appleseed@example.com", "testAppleId", "testAppleIdCode");

            // Act
            string newAppleId = "newTestAppleId";
            appleLogInRequestDto.AppleId = newAppleId;

            // Assert
            Assert.AreEqual(newAppleId, appleLogInRequestDto.AppleId);
        }

        [Test]
        public void AppleIdCode_SetAndGetProperties_AreEqual()
        {
            // Arrange
            AppleLogInRequestDto appleLogInRequestDto = new AppleLogInRequestDto("John Appleseed", "john.appleseed@example.com", "testAppleId", "testAppleIdCode");

            // Act
            string newAppleIdCode = "newTestAppleIdCode";
            appleLogInRequestDto.AppleIdCode = newAppleIdCode;

            // Assert
            Assert.AreEqual(newAppleIdCode, appleLogInRequestDto.AppleIdCode);
        }
    }
}
