namespace Disco.Test.ApiServices.Features.Account.Admin.RequestHandlers.LogIn
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Interfaces;
    using NUnit.Framework;

    [TestFixture]
    public class LogInRequestHandlerTests
    {
        private LogInRequestHandler _testClass;
        private IAccountService _accountService;
        private IAccountPasswordService _accountPasswordService;
        private ITokenService _tokenService;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _testClass = new LogInRequestHandler(_accountService, _accountPasswordService, _tokenService, _mapper);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn.LogInRequest(new LoginDto()
            {
                Email = "TestValue393947024",
                Password = "TestValue727404845"
            })
            {

            };
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn.LogInRequest), CancellationToken.None));
        }
    }
}