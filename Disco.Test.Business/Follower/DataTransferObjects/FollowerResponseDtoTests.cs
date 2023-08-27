namespace Disco.Test.Business.Follower.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using Disco.Business.Interfaces.Dtos.Followers;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class FollowerResponseDtoTests
    {
        private FollowerResponseDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new FollowerResponseDto();
        }

        [Test]
        public void CanSetAndGetFollowingAccount()
        {
            // Arrange
            var testValue = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1943022430",
                    FollowersCount = 1832865533,
                    NextStatusId = 329752789,
                    UserTarget = 1744586244,
                    AccountId = 114170094,
                    Account = default
                },
                Cread = "TestValue1106051536",
                Photo = "TestValue1941370377",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 2063136942,
                User = new User
                {
                    RoleName = "TestValue743593997",
                    RefreshToken = "TestValue1614442437",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1243475132,
                    Account = default
                }
            };

            // Act
            _testClass.FollowingAccount = testValue;

            // Assert
            Assert.That(_testClass.FollowingAccount, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetFollowerAccount()
        {
            // Arrange
            var testValue = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1311484150",
                    FollowersCount = 597060625,
                    NextStatusId = 412453173,
                    UserTarget = 773296663,
                    AccountId = 1008726555,
                    Account = default
                },
                Cread = "TestValue275171253",
                Photo = "TestValue1785389697",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 756901914,
                User = new User
                {
                    RoleName = "TestValue2007136975",
                    RefreshToken = "TestValue1204180328",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1468533354,
                    Account = default
                }
            };

            // Act
            _testClass.FollowerAccount = testValue;

            // Assert
            Assert.That(_testClass.FollowerAccount, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetIsFollowing()
        {
            // Arrange
            var testValue = true;

            // Act
            _testClass.IsFollowing = testValue;

            // Assert
            Assert.That(_testClass.IsFollowing, Is.EqualTo(testValue));
        }
    }
}