namespace Disco.Test.Business.Account.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class UserResponseDtoTests
    {
        private UserResponseDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new UserResponseDto();
        }

        [Test]
        public void CanSetAndGetUser()
        {
            // Arrange
            var testValue = new User
            {
                RoleName = "TestValue5869406",
                RefreshToken = "TestValue402163328",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 638263043,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1458134171",
                        FollowersCount = 1887688890,
                        NextStatusId = 414837802,
                        UserTarget = 361719293,
                        AccountId = 518809938,
                        Account = default
                    },
                    Cread = "TestValue1102445227",
                    Photo = "TestValue125344327",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1625015041,
                    User = default
                }
            };

            // Act
            _testClass.User = testValue;

            // Assert
            Assert.That(_testClass.User, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetAccessToken()
        {
            // Arrange
            var testValue = "TestValue17905186";

            // Act
            _testClass.AccessToken = testValue;

            // Assert
            Assert.That(_testClass.AccessToken, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetRefreshToken()
        {
            // Arrange
            var testValue = "TestValue848827424";

            // Act
            _testClass.RefreshToken = testValue;

            // Assert
            Assert.That(_testClass.RefreshToken, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccessTokenExpirce()
        {
            // Arrange
            var testValue = 1550508391;

            // Act
            _testClass.AccessTokenExpirce = testValue;

            // Assert
            Assert.That(_testClass.AccessTokenExpirce, Is.EqualTo(testValue));
        }
    }
}