//namespace Disco.Test.Business.Features.Account.User.RequestHandlers.RefreshToken
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using AutoMapper;
//    using Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken;
//    using Disco.ApiServices.Features.Account.User.RequestHandlers.RefreshToken;
//    using Disco.Business.Interfaces.Dtos.Account;
//    using Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken;
//    using Disco.Business.Interfaces.Interfaces;
//    using Disco.Business.Services.Mappers;
//    using Disco.Domain.Models.Models;
//    using Moq;
//    using NUnit.Framework;

//    [TestFixture]
//    public class RefreshTokenRequestHandlerTests
//    {
//        private RefreshTokenRequestHandler _testClass;
//        private Mock<IAccountService> _accountService;
//        private Mock<ITokenService> _tokenService;
        
//        private IMapper _mapper;

//        [SetUp]
//        public void SetUp()
//        {
//            _accountService = new Mock<IAccountService>();
//            _tokenService = new Mock<ITokenService>();
            
//            _mapper = new MapperConfiguration(x => x.AddProfile(new AccountMapProfile())).CreateMapper();
            
//            _testClass = new RefreshTokenRequestHandler(_accountService.Object, _tokenService.Object, _mapper);
//        }

//        [Test]
//        public void CanConstruct()
//        {
//            // Act
//            var instance = new RefreshTokenRequestHandler(_accountService.Object, _tokenService.Object, _mapper);

//            // Assert
//            Assert.That(instance, Is.Not.Null);
//        }

//        [Test]
//        public async Task CanCallHandle()
//        {
//            // Arrange
//            var request = new Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken.RefreshTokenRequest(new Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken.RefreshTokenRequestDto(
//                "TestValue589974837",
//                "TestValue241422784"
//            ));
//            var cancellationToken = CancellationToken.None;

//            _accountService.Setup(mock => mock.GetByRefreshTokenAsync(It.IsAny<string>())).ReturnsAsync(new User
//            {
//                RoleName = "TestValue2102671985",
//                RefreshToken = "TestValue507167850",
//                RefreshTokenExpiress = DateTime.UtcNow,
//                DateOfRegister = DateTime.UtcNow,
//                AccountId = 1382282278,
//                Account = new Account
//                {
//                    AccountStatus = new AccountStatus
//                    {
//                        LastStatus = "TestValue1055421416",
//                        FollowersCount = 1158525643,
//                        NextStatusId = 1450231632,
//                        UserTarget = 322472235,
//                        AccountId = 572244654,
//                        Account = default(Account)
//                    },
//                    Cread = "TestValue221353102",
//                    Photo = "TestValue1260487563",
//                    AccountGroups = new List<AccountGroup>(),
//                    Connections = new List<Connection>(),
//                    Messages = new List<Message>(),
//                    Posts = new List<Post>(),
//                    Comments = new List<Comment>(),
//                    Likes = new List<Like>(),
//                    Followers = new List<UserFollower>(),
//                    Following = new List<UserFollower>(),
//                    Stories = new List<Story>(),
//                    UserId = 1880873792,
//                    User = default(User)
//                }
//            });
//            _accountService.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();
//            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue1640774998");
//            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue2064753554");

//            // Act
//            var result = await _testClass.Handle(request, cancellationToken);

//            // Assert
//            _accountService.Verify(mock => mock.GetByRefreshTokenAsync(It.IsAny<string>()));
//            _accountService.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Never());
//            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
//            _tokenService.Verify(mock => mock.GenerateRefreshToken(), Times.Never());
//        }
        
//        [Test]
//        public async Task CanCallHandleWithExpiredRefreshToken()
//        {
//            // Arrange
//            var request = new Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken.RefreshTokenRequest(new RefreshTokenRequestDto(
//                "TestValue589974837",
//                "TestValue241422784"
//            ));
//            var cancellationToken = CancellationToken.None;

//            _accountService.Setup(mock => mock.GetByRefreshTokenAsync(It.IsAny<string>())).ReturnsAsync(new User
//            {
//                RoleName = "TestValue2102671985",
//                RefreshToken = "TestValue507167850",
//                RefreshTokenExpiress = DateTime.UtcNow.AddDays(8),
//                DateOfRegister = DateTime.UtcNow,
//                AccountId = 1382282278,
//                Account = new Account
//                {
//                    AccountStatus = new AccountStatus
//                    {
//                        LastStatus = "TestValue1055421416",
//                        FollowersCount = 1158525643,
//                        NextStatusId = 1450231632,
//                        UserTarget = 322472235,
//                        AccountId = 572244654,
//                        Account = default(Account)
//                    },
//                    Cread = "TestValue221353102",
//                    Photo = "TestValue1260487563",
//                    AccountGroups = new List<AccountGroup>(),
//                    Connections = new List<Connection>(),
//                    Messages = new List<Message>(),
//                    Posts = new List<Post>(),
//                    Comments = new List<Comment>(),
//                    Likes = new List<Like>(),
//                    Followers = new List<UserFollower>(),
//                    Following = new List<UserFollower>(),
//                    Stories = new List<Story>(),
//                    UserId = 1880873792,
//                    User = default(User)
//                }
//            });
//            _accountService.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();
//            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue1640774998");
//            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue2064753554");

//            // Act
//            var result = await _testClass.Handle(request, cancellationToken);

//            // Assert
//            _accountService.Verify(mock => mock.GetByRefreshTokenAsync(It.IsAny<string>()));
//            _accountService.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Once());
//            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
//            _tokenService.Verify(mock => mock.GenerateRefreshToken(), Times.Once());
//        }

//        [Test]
//        public void CannotCallHandleWithNullRequest()
//        {
//           Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken.RefreshTokenRequest), CancellationToken.None));
//        }
//    }
//}