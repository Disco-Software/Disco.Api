namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class CommentTests
    {
        private Comment _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Comment();
        }

        [Test]
        public void CanSetAndGetCommentDescription()
        {
            // Arrange
            var testValue = "TestValue859405569";

            // Act
            _testClass.CommentDescription = testValue;

            // Assert
            Assert.That(_testClass.CommentDescription, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 132000176;

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
                    LastStatus = "TestValue1995713401",
                    FollowersCount = 308493647,
                    NextStatusId = 340601778,
                    UserTarget = 1266061612,
                    AccountId = 1672355766,
                    Account = default(Account)
                },
                Cread = "TestValue2084289015",
                Photo = "TestValue1892599925",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 2115602515,
                User = new User
                {
                    RoleName = "TestValue1747069142",
                    RefreshToken = "TestValue1030336269",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 737429848,
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
            var testValue = 845488207;

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
                Description = "TestValue1528101861",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 732018399,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1973492759",
                        FollowersCount = 1589073889,
                        NextStatusId = 661312484,
                        UserTarget = 775055421,
                        AccountId = 751520268,
                        Account = default(Account)
                    },
                    Cread = "TestValue1836084346",
                    Photo = "TestValue940607572",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 113487944,
                    User = new User
                    {
                        RoleName = "TestValue1225591808",
                        RefreshToken = "TestValue1040051378",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1876340652,
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