namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class AccountTests
    {
        private Account _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Account();
        }

        [Test]
        public void CanSetAndGetAccountStatus()
        {
            // Arrange
            var testValue = new AccountStatus
            {
                LastStatus = "TestValue1478748102",
                FollowersCount = 91677869,
                NextStatusId = 1708326641,
                UserTarget = 668851423,
                AccountId = 244891321,
                Account = new Account
                {
                    AccountStatus = default(AccountStatus),
                    Cread = "TestValue1783290717",
                    Photo = "TestValue383712168",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 582533924,
                    User = new User
                    {
                        RoleName = "TestValue55911690",
                        RefreshToken = "TestValue2087949511",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 775242960,
                        Account = default(Account)
                    }
                }
            };

            // Act
            _testClass.AccountStatus = testValue;

            // Assert
            Assert.That(_testClass.AccountStatus, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetCread()
        {
            // Arrange
            var testValue = "TestValue2147380821";

            // Act
            _testClass.Cread = testValue;

            // Assert
            Assert.That(_testClass.Cread, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPhoto()
        {
            // Arrange
            var testValue = "TestValue1532321645";

            // Act
            _testClass.Photo = testValue;

            // Assert
            Assert.That(_testClass.Photo, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccountGroups()
        {
            // Arrange
            var testValue = new List<AccountGroup>();

            // Act
            _testClass.AccountGroups = testValue;

            // Assert
            Assert.That(_testClass.AccountGroups, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetConnections()
        {
            // Arrange
            var testValue = new List<Connection>();

            // Act
            _testClass.Connections = testValue;

            // Assert
            Assert.That(_testClass.Connections, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetMessages()
        {
            // Arrange
            var testValue = new List<Message>();

            // Act
            _testClass.Messages = testValue;

            // Assert
            Assert.That(_testClass.Messages, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPosts()
        {
            // Arrange
            var testValue = new List<Post>();

            // Act
            _testClass.Posts = testValue;

            // Assert
            Assert.That(_testClass.Posts, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetComments()
        {
            // Arrange
            var testValue = new List<Comment>();

            // Act
            _testClass.Comments = testValue;

            // Assert
            Assert.That(_testClass.Comments, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetLikes()
        {
            // Arrange
            var testValue = new List<Like>();

            // Act
            _testClass.Likes = testValue;

            // Assert
            Assert.That(_testClass.Likes, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetFollowers()
        {
            // Arrange
            var testValue = new List<UserFollower>();

            // Act
            _testClass.Followers = testValue;

            // Assert
            Assert.That(_testClass.Followers, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetFollowing()
        {
            // Arrange
            var testValue = new List<UserFollower>();

            // Act
            _testClass.Following = testValue;

            // Assert
            Assert.That(_testClass.Following, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetStories()
        {
            // Arrange
            var testValue = new List<Story>();

            // Act
            _testClass.Stories = testValue;

            // Assert
            Assert.That(_testClass.Stories, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetUserId()
        {
            // Arrange
            var testValue = 224808515;

            // Act
            _testClass.UserId = testValue;

            // Assert
            Assert.That(_testClass.UserId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetUser()
        {
            // Arrange
            var testValue = new User
            {
                RoleName = "TestValue1570102301",
                RefreshToken = "TestValue1785601482",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 823180589,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1194800507",
                        FollowersCount = 940939350,
                        NextStatusId = 630227095,
                        UserTarget = 1179560829,
                        AccountId = 2017625714,
                        Account = default(Account)
                    },
                    Cread = "TestValue1357295955",
                    Photo = "TestValue574100809",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 219966518,
                    User = default(User)
                }
            };

            // Act
            _testClass.User = testValue;

            // Assert
            Assert.That(_testClass.User, Is.SameAs(testValue));
        }
    }
}