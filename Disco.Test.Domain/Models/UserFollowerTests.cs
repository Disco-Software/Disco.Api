namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class UserFollowerTests
    {
        private UserFollower _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new UserFollower();
        }

        [Test]
        public void CanSetAndGetFollowingAccountId()
        {
            // Arrange
            var testValue = 1817274724;

            // Act
            _testClass.FollowingAccountId = testValue;

            // Assert
            Assert.That(_testClass.FollowingAccountId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetFollowingAccount()
        {
            // Arrange
            var testValue = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue842799221",
                    FollowersCount = 2019478272,
                    NextStatusId = 1176270773,
                    UserTarget = 1645435824,
                    AccountId = 283218157,
                    Account = default(Account)
                },
                Cread = "TestValue1796366020",
                Photo = "TestValue1048530647",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 147206817,
                User = new User
                {
                    RoleName = "TestValue339713709",
                    RefreshToken = "TestValue1606642272",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1042678819,
                    Account = default(Account)
                }
            };

            // Act
            _testClass.FollowingAccount = testValue;

            // Assert
            Assert.That(_testClass.FollowingAccount, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetFollowerAccountId()
        {
            // Arrange
            var testValue = 979651296;

            // Act
            _testClass.FollowerAccountId = testValue;

            // Assert
            Assert.That(_testClass.FollowerAccountId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetFollowerAccount()
        {
            // Arrange
            var testValue = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1782323462",
                    FollowersCount = 727200285,
                    NextStatusId = 1609726894,
                    UserTarget = 914664623,
                    AccountId = 2090697645,
                    Account = default(Account)
                },
                Cread = "TestValue1174332982",
                Photo = "TestValue1582170275",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 929454224,
                User = new User
                {
                    RoleName = "TestValue1975391694",
                    RefreshToken = "TestValue358986214",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1799274110,
                    Account = default(Account)
                }
            };

            // Act
            _testClass.FollowerAccount = testValue;

            // Assert
            Assert.That(_testClass.FollowerAccount, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetIsFollowing()
        {
            // Arrange
            var testValue = true;

            // Act
            _testClass.IsFollowing = testValue;

            // Assert
            Assert.That(_testClass.IsFollowing, Is.EqualTo(testValue));
        }
    }
}