//namespace Disco.Test.ApiServices.Features.AccountDetails.Admin.RequestHandlers.CreateAccount
//{
//    using System;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using AutoMapper;
//    using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.CreateAccount;
//    using Disco.Business.Interfaces.Dtos.Account;
//    using Disco.Business.Interfaces.Interfaces;
//    using Disco.Business.Services.Mappers;
//    using Disco.Domain.Models.Models;
//    using NSubstitute;
//    using NUnit.Framework;

//    [TestFixture]
//    public class CreateAccountRequestHandlerTests
//    {
//        private CreateAccountRequestHandler _testClass;
//        private IAccountService _accountService;
//        private ITokenService _tokenService;
//        private IMapper _mapper;

//        [SetUp]
//        public void SetUp()
//        {
//            _accountService = Substitute.For<IAccountService>();
//            _tokenService = Substitute.For<ITokenService>();

//            _mapper = new MapperConfiguration(x => x.AddProfile(new AccountMapProfile())).CreateMapper();
            
//            _testClass = new CreateAccountRequestHandler(_accountService, _tokenService, _mapper);
//        }

//        [Test]
//        public void CanConstruct()
//        {
//            // Act
//            var instance = new CreateAccountRequestHandler(_accountService, _tokenService, _mapper);

//            // Assert
//            Assert.That(instance, Is.Not.Null);
//        }


//        [Test]
//        public async Task CanCallHandle()
//        {
//            // Arrange
//            var request = new CreateAccountRequest(new RegisterRequestDto
//            {
//                UserName = "TestValue1149161230",
//                Email = "TestValue28072517",
//                Password = "TestValue1978507675",
//                ConfirmPassword = "TestValue121318841"
//            });
//            var cancellationToken = CancellationToken.None;

//            _tokenService.GenerateAccessToken(Arg.Any<User>()).Returns("TestValue1029441257");
//            _tokenService.GenerateRefreshToken().Returns("TestValue1328808548");

//            // Act
//            var result = await _testClass.Handle(request, cancellationToken);

//            // Assert
//            await _accountService.Received().CreateAsync(Arg.Any<User>());
//            await _accountService.Received().SaveRefreshTokenAsync(Arg.Any<User>(), Arg.Any<string>());
//            _tokenService.Received().GenerateAccessToken(Arg.Any<User>());
//            _tokenService.Received().GenerateRefreshToken();
//        }

//        [Test]
//        public void CannotCallHandleWithNullRequest()
//        {
//            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(CreateAccountRequest), CancellationToken.None));
//        }
//    }
//}