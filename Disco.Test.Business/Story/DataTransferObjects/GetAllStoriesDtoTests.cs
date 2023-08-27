namespace Disco.Test.Business.Story.Stories
{
    using System;
    using Disco.Business.Interfaces.Dtos.Stories;
    using NUnit.Framework;

    [TestFixture]
    public class GetAllStoriesDtoTests
    {
        private GetAllStoriesDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetAllStoriesDto();
        }

        [Test]
        public void CanSetAndGetPageNumber()
        {
            // Arrange
            var testValue = 759786561;

            // Act
            _testClass.PageNumber = testValue;

            // Assert
            Assert.That(_testClass.PageNumber, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPageSize()
        {
            // Arrange
            var testValue = 47105314;

            // Act
            _testClass.PageSize = testValue;

            // Assert
            Assert.That(_testClass.PageSize, Is.EqualTo(testValue));
        }
    }
}