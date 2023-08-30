namespace Disco.Domain.Events.Test.Dto
{
    using System;
    using Disco.Domain.Events.Dto;
    using NUnit.Framework;

    [TestFixture]
    public class PostVideoDtoTests
    {
        private PostVideoDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new PostVideoDto();
        }

        [Test]
        public void CanSetAndGetVideoSource()
        {
            // Arrange
            var testValue = "TestValue1355375071";

            // Act
            _testClass.VideoSource = testValue;

            // Assert
            Assert.That(_testClass.VideoSource, Is.EqualTo(testValue));
        }
    }
}