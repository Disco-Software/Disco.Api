namespace Disco.Domain.Events.Test.Dto
{
    using System;
    using Disco.Domain.Events.Dto;
    using NUnit.Framework;

    [TestFixture]
    public class LikeDtoTests
    {
        private LikeDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new LikeDto();
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 343822257;

            // Act
            _testClass.AccountId = testValue;

            // Assert
            Assert.That(_testClass.AccountId, Is.EqualTo(testValue));
        }
    }
}