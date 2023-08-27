namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.GetRecomended
{
    using System;
    using Disco.ApiServices.Features.Follower.RequestHandlers.GetRecomended;
    using NUnit.Framework;

    [TestFixture]
    public class GetRecomendedRequestTests
    {
        private GetRecomendedRequest _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetRecomendedRequest();
        }
    }
}