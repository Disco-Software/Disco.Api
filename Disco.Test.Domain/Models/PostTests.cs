namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class PostTests
    {
        private Post _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Post();
        }

        [Test]
        public void CanSetAndGetDescription()
        {
            // Arrange
            var testValue = "TestValue1689527241";

            // Act
            _testClass.Description = testValue;

            // Assert
            Assert.That(_testClass.Description, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPostImages()
        {
            // Arrange
            var testValue = new List<PostImage>();

            // Act
            _testClass.PostImages = testValue;

            // Assert
            Assert.That(_testClass.PostImages, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPostSongs()
        {
            // Arrange
            var testValue = new List<PostSong>();

            // Act
            _testClass.PostSongs = testValue;

            // Assert
            Assert.That(_testClass.PostSongs, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPostVideos()
        {
            // Arrange
            var testValue = new List<PostVideo>();

            // Act
            _testClass.PostVideos = testValue;

            // Assert
            Assert.That(_testClass.PostVideos, Is.SameAs(testValue));
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
            var testValue = 1483718469;

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
                    LastStatus = "TestValue2067602053",
                    FollowersCount = 738708220,
                    NextStatusId = 1002158450,
                    UserTarget = 135554794,
                    AccountId = 400094217,
                    Account = default(Account)
                },
                Cread = "TestValue595328488",
                Photo = "TestValue593673754",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 728827719,
                User = new User
                {
                    RoleName = "TestValue476540896",
                    RefreshToken = "TestValue1165887075",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 814373028,
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