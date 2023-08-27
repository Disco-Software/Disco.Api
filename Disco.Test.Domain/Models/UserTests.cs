namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class UserTests
    {
        private User _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new User();
        }

        [Test]
        public void CanSetAndGetRoleName()
        {
            // Arrange
            var testValue = "TestValue1055770063";

            // Act
            _testClass.RoleName = testValue;

            // Assert
            Assert.That(_testClass.RoleName, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetRefreshToken()
        {
            // Arrange
            var testValue = "TestValue365688423";

            // Act
            _testClass.RefreshToken = testValue;

            // Assert
            Assert.That(_testClass.RefreshToken, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetRefreshTokenExpiress()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.RefreshTokenExpiress = testValue;

            // Assert
            Assert.That(_testClass.RefreshTokenExpiress, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetDateOfRegister()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.DateOfRegister = testValue;

            // Assert
            Assert.That(_testClass.DateOfRegister, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 1906278550;

            // Act
            _testClass.AccountId = testValue;

            // Assert
            Assert.That(_testClass.AccountId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccount()
        {
            // Arrange
            var testValue = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1053682844",
                    FollowersCount = 1261975514,
                    NextStatusId = 2065268623,
                    UserTarget = 1403088574,
                    AccountId = 1192721410,
                    Account = default(Account)
                },
                Cread = "TestValue1275403446",
                Photo = "TestValue234268308",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 709410906,
                User = new User
                {
                    RoleName = "TestValue686176753",
                    RefreshToken = "TestValue396952449",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 302820388,
                    Account = default(Account)
                }
            };

            // Act
            _testClass.Account = testValue;

            // Assert
            Assert.That(_testClass.Account, Is.SameAs(testValue));
        }
    }
}