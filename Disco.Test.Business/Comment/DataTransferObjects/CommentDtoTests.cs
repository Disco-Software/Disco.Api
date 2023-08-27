namespace Disco.Test.Business.Comment.DataTransferObjects
{
    using System;
    using Disco.Business.Interfaces.Dtos.Chat;
    using Disco.Business.Interfaces.Dtos.Comments;
    using NUnit.Framework;

    [TestFixture]
    public class CommentDtoTests
    {
        private CommentDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new CommentDto();
        }

        [Test]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1982561985;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.That(_testClass.Id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetDescription()
        {
            // Arrange
            var testValue = "TestValue1958438743";

            // Act
            _testClass.Description = testValue;

            // Assert
            Assert.That(_testClass.Description, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccount()
        {
            // Arrange
            var testValue = new AccountDto
            {
                Id = 980504119,
                Photo = "TestValue452755596",
                User = new UserDto
                {
                    Id = 1194182100,
                    Name = "TestValue1632465339"
                }
            };

            // Act
            _testClass.Account = testValue;

            // Assert
            Assert.That(_testClass.Account, Is.SameAs(testValue));
        }
    }
}