namespace Disco.Test.Business.Post.DataTransferObjects
{
    using System;
    using Disco.Business.Interfaces.Dtos.Posts;
    using NUnit.Framework;

    [TestFixture]
    public class GetAllPostsDtoTests
    {
        private GetAllPostsDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetAllPostsDto();
        }

        [Test]
        public void CanSetAndGetPageNumber()
        {
            // Arrange
            var testValue = 1578985842;

            // Act
            _testClass.PageNumber = testValue;

            // Assert
            Assert.That(_testClass.PageNumber, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPageSize()
        {
            // Arrange
            var testValue = 1933082184;

            // Act
            _testClass.PageSize = testValue;

            // Assert
            Assert.IsNotNull(_testClass.PageSize);
        }
    }
}