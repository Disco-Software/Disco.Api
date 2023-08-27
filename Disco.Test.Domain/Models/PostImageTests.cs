namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class PostImageTests
    {
        private PostImage _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new PostImage();
        }

        [Test]
        public void CanSetAndGetSource()
        {
            // Arrange
            var testValue = "TestValue2007407123";

            // Act
            _testClass.Source = testValue;

            // Assert
            Assert.That(_testClass.Source, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPostId()
        {
            // Arrange
            var testValue = 1716721679;

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
                Description = "TestValue1170562355",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 768729820,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue555472979",
                        FollowersCount = 834454444,
                        NextStatusId = 728559228,
                        UserTarget = 422332831,
                        AccountId = 917864630,
                        Account = default(Account)
                    },
                    Cread = "TestValue1584599237",
                    Photo = "TestValue951752165",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 340791261,
                    User = new User
                    {
                        RoleName = "TestValue1529036689",
                        RefreshToken = "TestValue1021927309",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1146369589,
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