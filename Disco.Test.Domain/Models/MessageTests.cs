namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class MessageTests
    {
        private Message _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Message();
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 1048644010;

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
                    LastStatus = "TestValue1382933409",
                    FollowersCount = 1350971157,
                    NextStatusId = 1160379702,
                    UserTarget = 885562811,
                    AccountId = 1307716291,
                    Account = default(Account)
                },
                Cread = "TestValue249034274",
                Photo = "TestValue270602822",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1906051300,
                User = new User
                {
                    RoleName = "TestValue837983036",
                    RefreshToken = "TestValue175823810",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1953910615,
                    Account = default(Account)
                }
            };

            // Act
            _testClass.Account = testValue;

            // Assert
            Assert.That(_testClass.Account, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetDescription()
        {
            // Arrange
            var testValue = "TestValue476346055";

            // Act
            _testClass.Description = testValue;

            // Assert
            Assert.That(_testClass.Description, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetCreatedDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.CreatedDate = testValue;

            // Assert
            Assert.That(_testClass.CreatedDate, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetGroupId()
        {
            // Arrange
            var testValue = 1929130906;

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
                Name = "TestValue1617255797",
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