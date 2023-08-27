namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class StoryTests
    {
        private Story _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Story();
        }

        [Test]
        public void CanSetAndGetStoryImages()
        {
            // Arrange
            var testValue = new List<StoryImage>();

            // Act
            _testClass.StoryImages = testValue;

            // Assert
            Assert.That(_testClass.StoryImages, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetStoryVideos()
        {
            // Arrange
            var testValue = new List<StoryVideo>();

            // Act
            _testClass.StoryVideos = testValue;

            // Assert
            Assert.That(_testClass.StoryVideos, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetDateOfCreation()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.DateOfCreation = testValue;

            // Assert
            Assert.That(_testClass.DateOfCreation, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 1533897292;

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
                    LastStatus = "TestValue1732491897",
                    FollowersCount = 3910813,
                    NextStatusId = 1262299142,
                    UserTarget = 168225181,
                    AccountId = 274845258,
                    Account = default(Account)
                },
                Cread = "TestValue105640423",
                Photo = "TestValue1295006663",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1734560836,
                User = new User
                {
                    RoleName = "TestValue1176981112",
                    RefreshToken = "TestValue1470544668",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 45265163,
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