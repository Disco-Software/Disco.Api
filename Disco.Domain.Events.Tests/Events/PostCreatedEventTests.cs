namespace Disco.Domain.Events.Test.Events
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Events.Dto;
    using Disco.Domain.Events.Events;
    using NUnit.Framework;

    [TestFixture]
    public class PostCreatedEventTests
    {
        private PostCreatedEvent _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new PostCreatedEvent();
        }

        [Test]
        public void CanSetAndGetDescription()
        {
            // Arrange
            var testValue = "TestValue1463645188";

            // Act
            _testClass.Description = testValue;

            // Assert
            Assert.That(_testClass.Description, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPostImages()
        {
            // Arrange
            var testValue = new List<PostImageDto>();

            // Act
            _testClass.PostImages = testValue;

            // Assert
            Assert.That(_testClass.PostImages, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPostSongs()
        {
            // Arrange
            var testValue = new List<PostSongDto>();

            // Act
            _testClass.PostSongs = testValue;

            // Assert
            Assert.That(_testClass.PostSongs, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPostVideos()
        {
            // Arrange
            var testValue = new List<PostSongDto>();

            // Act
            _testClass.PostVideos = testValue;

            // Assert
            Assert.That(_testClass.PostVideos, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetLikes()
        {
            // Arrange
            var testValue = new List<LikeDto>();

            // Act
            _testClass.Likes = testValue;

            // Assert
            Assert.That(_testClass.Likes, Is.SameAs(testValue));
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
        public void CanSetAndGetAccount()
        {
            // Arrange
            var testValue = new AccountDto
            {
                Id = 2044475097,
                Photo = "TestValue832431826",
                UserFollowerDtos = new List<UserFollowerDto>(),
                UserFollowingDtos = new List<UserFollowerDto>(),
                UserDto = new UserDto
                {
                    Id = 166738599,
                    UserName = "TestValue503521118"
                }
            };

            // Act
            _testClass.Account = testValue;

            // Assert
            Assert.That(_testClass.Account, Is.SameAs(testValue));
        }
    }
}