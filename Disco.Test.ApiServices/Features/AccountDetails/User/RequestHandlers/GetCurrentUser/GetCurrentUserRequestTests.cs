namespace Disco.Test.ApiServices.Features.AccountDetails.User.RequestHandlers.GetCurrentUser
{
    using System;
    using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetCurrentUser;
    using NUnit.Framework;

    [TestFixture]
    public class GetCurrentUserRequestTests
    {
        private GetCurrentUserRequest _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetCurrentUserRequest();
        }
    }
}