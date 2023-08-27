namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class StoryImageTests
    {
        private StoryImage _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new StoryImage();
        }

        [Test]
        public void CanSetAndGetSource()
        {
            // Arrange
            var testValue = "TestValue1110235319";

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
            var testValue = 1501066075;

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
                AccountId = 520383333,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1483369534",
                        FollowersCount = 860254539,
                        NextStatusId = 892496253,
                        UserTarget = 457689110,
                        AccountId = 2134979308,
                        Account = default(Account)
                    },
                    Cread = "TestValue319813266",
                    Photo = "TestValue1212066824",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 287557479,
                    User = new User
                    {
                        RoleName = "TestValue1551522933",
                        RefreshToken = "TestValue65844762",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1709046035,
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