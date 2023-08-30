namespace Disco.Domain.Events.Test.Dto
{
    using System;
    using Disco.Domain.Events.Dto;
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
        public void CanSetAndGetCommentDescription()
        {
            // Arrange
            var testValue = "TestValue957353447";

            // Act
            _testClass.CommentDescription = testValue;

            // Assert
            Assert.That(_testClass.CommentDescription, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 1364393837;

            // Act
            _testClass.AccountId = testValue;

            // Assert
            Assert.That(_testClass.AccountId, Is.EqualTo(testValue));
        }
    }
}