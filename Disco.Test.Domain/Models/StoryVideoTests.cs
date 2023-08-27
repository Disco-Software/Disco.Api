namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class StoryVideoTests
    {
        private StoryVideo _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new StoryVideo();
        }

        [Test]
        public void CanSetAndGetSource()
        {
            // Arrange
            var testValue = "TestValue731890734";

            // Act
            _testClass.Source = testValue;

            // Assert
            Assert.That(_testClass.Source, Is.EqualTo(testValue));
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
        public void CanSetAndGetStoryId()
        {
            // Arrange
            var testValue = 1274575503;

            // Act
            _testClass.StoryId = testValue;

            // Assert
            Assert.That(_testClass.StoryId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetStory()
        {
            // Arrange
            var testValue = new Story
            {
                StoryImages = new List<StoryImage>(),
                StoryVideos = new List<StoryVideo>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 2084147025,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue53289171",
                        FollowersCount = 842112027,
                        NextStatusId = 1527151656,
                        UserTarget = 1312093586,
                        AccountId = 752057995,
                        Account = default(Account)
                    },
                    Cread = "TestValue774623330",
                    Photo = "TestValue251191302",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 316726573,
                    User = new User
                    {
                        RoleName = "TestValue578048415",
                        RefreshToken = "TestValue1735059700",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 98404148,
                        Account = default(Account)
                    }
                }
            };

            // Act
            _testClass.Story = testValue;

            // Assert
            Assert.That(_testClass.Story, Is.SameAs(testValue));
        }
    }
}