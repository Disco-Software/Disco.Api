namespace Disco.Domain.Events.Test.Dto
{
    using System;
    using Disco.Domain.Events.Dto;
    using NUnit.Framework;

    [TestFixture]
    public class PostImageDtoTests
    {
        private PostImageDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new PostImageDto();
        }

        [Test]
        public void CanSetAndGetSource()
        {
            // Arrange
            var testValue = "TestValue1072251638";

            // Act
            _testClass.Source = testValue;

            // Assert
            Assert.That(_testClass.Source, Is.EqualTo(testValue));
        }
    }
}