namespace Disco.Domain.Events.Test.Dto
{
    using System;
    using Disco.Domain.Events.Dto;
    using NUnit.Framework;

    [TestFixture]
    public class UserFollowerDtoTests
    {
        private UserFollowerDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new UserFollowerDto();
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 678152450;

            // Act
            _testClass.AccountId = testValue;

            // Assert
            Assert.That(_testClass.AccountId, Is.EqualTo(testValue));
        }
    }
}