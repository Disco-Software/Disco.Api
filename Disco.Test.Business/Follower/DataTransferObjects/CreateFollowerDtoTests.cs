namespace Disco.Test.Business.Follower.DataTransferObjects
{
    using System;
    using Disco.Business.Interfaces.Dtos.Friends;
    using NUnit.Framework;

    [TestFixture]
    public class CreateFollowerDtoTests
    {
        private CreateFollowerDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new CreateFollowerDto();
        }

        [Test]
        public void CanSetAndGetFollowingAccountId()
        {
            // Arrange
            var testValue = 357814541;

            // Act
            _testClass.FollowingAccountId = testValue;

            // Assert
            Assert.That(_testClass.FollowingAccountId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetIntalationId()
        {
            // Arrange
            var testValue = "TestValue1579467005";

            // Act
            _testClass.IntalationId = testValue;

            // Assert
            Assert.That(_testClass.IntalationId, Is.EqualTo(testValue));
        }
    }
}