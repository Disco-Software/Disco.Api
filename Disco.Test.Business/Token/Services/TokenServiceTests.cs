namespace Disco.Test.Business.Token.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Disco.Business.Interfaces.Options;
    using Disco.Business.Services.Services;
    using Disco.Domain.Models.Models;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class TokenServiceTests
    {
        private TokenService _testClass;
        private Mock<IOptions<AuthenticationOptions>> _options;

        [SetUp]
        public void SetUp()
        {
            _options = new Mock<IOptions<AuthenticationOptions>>();
            _testClass = new TokenService(_options.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new TokenService(_options.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallGenerateAccessToken()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue300287341",
                RefreshToken = "TestValue1861481092",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 857913005,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue2068675300",
                        FollowersCount = 760554220,
                        NextStatusId = 1879127,
                        UserTarget = 184915188,
                        AccountId = 1878130275,
                        Account = default
                    },
                    Cread = "TestValue733738033",
                    Photo = "TestValue258888320",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1550519282,
                    User = default
                }
            };

            var authenticationOptions = new AuthenticationOptions
            {
                Issuer = "disco-api",
                Audience = "http://localhost/Disco.Api",
                SigningKey = "c3RhcyBrb3JjaGV2c2t5aQ==",
                ExpiresAfterMitutes = 300,
            };

            _options.Setup(x => x.Value)
                .Returns(authenticationOptions);
                
            // Act
            var result = _testClass.GenerateAccessToken(user);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void CannotCallGenerateAccessTokenWithNullUser()
        {
            Assert.Throws<NullReferenceException>(() => _testClass.GenerateAccessToken(default));
        }

        [Test]
        public void CanCallGenerateRefreshToken()
        {
            // Act
            var result = _testClass.GenerateRefreshToken();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}