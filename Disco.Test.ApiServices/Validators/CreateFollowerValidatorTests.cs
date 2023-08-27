namespace Disco.Test.ApiServices.Validators
{
    using System;
    using System.Security.Claims;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Business.Interfaces.Validators;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CreateFollowerValidatorTests
    {
        private CreateFollowerValidator _testClass;
        private IHttpContextAccessor _contextAccessor;
        private IAccountService _accountService;

        [SetUp]
        public void SetUp()
        {
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _accountService = Substitute.For<IAccountService>();
            _testClass = new CreateFollowerValidator(_accountService, _contextAccessor.HttpContext.User);
        }
    }
}