namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class PostVideoTests
    {
        private PostVideo _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new PostVideo();
        }

        [Test]
        public void CanSetAndGetVideoSource()
        {
            // Arrange
            var testValue = "TestValue1228191027";

            // Act
            _testClass.VideoSource = testValue;

            // Assert
            Assert.That(_testClass.VideoSource, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPostId()
        {
            // Arrange
            var testValue = 372076211;

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
                Description = "TestValue286522297",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 121933867,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1725655778",
                        FollowersCount = 2028079322,
                        NextStatusId = 629893203,
                        UserTarget = 1315135836,
                        AccountId = 694856207,
                        Account = default(Account)
                    },
                    Cread = "TestValue1457128867",
                    Photo = "TestValue1067730122",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1530062476,
                    User = new User
                    {
                        RoleName = "TestValue355015185",
                        RefreshToken = "TestValue529872764",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1853710558,
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