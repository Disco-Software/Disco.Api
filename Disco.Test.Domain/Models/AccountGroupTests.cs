namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class AccountGroupTests
    {
        private AccountGroup _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new AccountGroup();
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 654360948;

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
                    LastStatus = "TestValue1184254669",
                    FollowersCount = 1145175455,
                    NextStatusId = 121051557,
                    UserTarget = 1687227358,
                    AccountId = 299280546,
                    Account = default(Account)
                },
                Cread = "TestValue2050565436",
                Photo = "TestValue1407813958",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1704201048,
                User = new User
                {
                    RoleName = "TestValue512052623",
                    RefreshToken = "TestValue451874053",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1581718167,
                    Account = default(Account)
                }
            };

            // Act
            _testClass.Account = testValue;

            // Assert
            Assert.That(_testClass.Account, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetGroupId()
        {
            // Arrange
            var testValue = 782364115;

            // Act
            _testClass.GroupId = testValue;

            // Assert
            Assert.That(_testClass.GroupId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetGroup()
        {
            // Arrange
            var testValue = new Group
            {
                Name = "TestValue1094237274",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };

            // Act
            _testClass.Group = testValue;

            // Assert
            Assert.That(_testClass.Group, Is.SameAs(testValue));
        }
    }
}