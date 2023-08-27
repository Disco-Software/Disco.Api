namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class AccountStatusTests
    {
        private AccountStatus _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new AccountStatus();
        }

        [Test]
        public void CanSetAndGetLastStatus()
        {
            // Arrange
            var testValue = "TestValue712833294";

            // Act
            _testClass.LastStatus = testValue;

            // Assert
            Assert.That(_testClass.LastStatus, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetFollowersCount()
        {
            // Arrange
            var testValue = 1822173752;

            // Act
            _testClass.FollowersCount = testValue;

            // Assert
            Assert.That(_testClass.FollowersCount, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetNextStatusId()
        {
            // Arrange
            var testValue = 2024940596;

            // Act
            _testClass.NextStatusId = testValue;

            // Assert
            Assert.That(_testClass.NextStatusId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetUserTarget()
        {
            // Arrange
            var testValue = 755211762;

            // Act
            _testClass.UserTarget = testValue;

            // Assert
            Assert.That(_testClass.UserTarget, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 286578402;

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
                    LastStatus = "TestValue1593456073",
                    FollowersCount = 34385374,
                    NextStatusId = 1896574157,
                    UserTarget = 1817552244,
                    AccountId = 274820263,
                    Account = default(Account)
                },
                Cread = "TestValue316884729",
                Photo = "TestValue568165628",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 2032781658,
                User = new User
                {
                    RoleName = "TestValue839270707",
                    RefreshToken = "TestValue506040953",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1622144349,
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