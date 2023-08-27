namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class PostSongTests
    {
        private PostSong _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new PostSong();
        }

        [Test]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1156960478";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.That(_testClass.Name, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetImageUrl()
        {
            // Arrange
            var testValue = "TestValue735405012";

            // Act
            _testClass.ImageUrl = testValue;

            // Assert
            Assert.That(_testClass.ImageUrl, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetSource()
        {
            // Arrange
            var testValue = "TestValue1024435722";

            // Act
            _testClass.Source = testValue;

            // Assert
            Assert.That(_testClass.Source, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetExecutorName()
        {
            // Arrange
            var testValue = "TestValue1705749011";

            // Act
            _testClass.ExecutorName = testValue;

            // Assert
            Assert.That(_testClass.ExecutorName, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPostId()
        {
            // Arrange
            var testValue = 1855294723;

            // Act
            _testClass.PostId = testValue;

            // Assert
            Assert.That(_testClass.PostId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPost()
        {
            // Arrange
            var testValue = new Post
            {
                Description = "TestValue610414096",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 2127402231,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue485719130",
                        FollowersCount = 1036766110,
                        NextStatusId = 842449414,
                        UserTarget = 1481019353,
                        AccountId = 415266822,
                        Account = default(Account)
                    },
                    Cread = "TestValue1770568130",
                    Photo = "TestValue1905973503",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2019014194,
                    User = new User
                    {
                        RoleName = "TestValue125844680",
                        RefreshToken = "TestValue840471273",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 48820856,
                        Account = default(Account)
                    }
                }
            };

            // Act
            _testClass.Post = testValue;

            // Assert
            Assert.That(_testClass.Post, Is.SameAs(testValue));
        }
    }
}