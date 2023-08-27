namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class LikeTests
    {
        private Like _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Like();
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 1448034047;

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
                    LastStatus = "TestValue1537204607",
                    FollowersCount = 1754472635,
                    NextStatusId = 1427051354,
                    UserTarget = 584830446,
                    AccountId = 1025351103,
                    Account = default(Account)
                },
                Cread = "TestValue1732251228",
                Photo = "TestValue875693218",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1973823366,
                User = new User
                {
                    RoleName = "TestValue728208231",
                    RefreshToken = "TestValue1163263302",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 557054790,
                    Account = default(Account)
                }
            };

            // Act
            _testClass.Account = testValue;

            // Assert
            Assert.That(_testClass.Account, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPostId()
        {
            // Arrange
            var testValue = 1821417116;

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
                Description = "TestValue1925293483",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 406817559,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1325892451",
                        FollowersCount = 1769777307,
                        NextStatusId = 994981060,
                        UserTarget = 1532449283,
                        AccountId = 1405879402,
                        Account = default(Account)
                    },
                    Cread = "TestValue1448738227",
                    Photo = "TestValue1978261897",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1944644911,
                    User = new User
                    {
                        RoleName = "TestValue1889207421",
                        RefreshToken = "TestValue1362103707",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 326119719,
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