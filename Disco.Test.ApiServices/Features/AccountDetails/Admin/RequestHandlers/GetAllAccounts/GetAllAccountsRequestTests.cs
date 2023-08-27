namespace Disco.Test.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts
{
    using System;
    using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts;
    using NUnit.Framework;

    [TestFixture]
    public class GetAllAccountsRequestTests
    {
        private GetAllAccountsRequest _testClass;
        private int _pageNumber;
        private int _pageSize;

        [SetUp]
        public void SetUp()
        {
            _pageNumber = 1361113665;
            _pageSize = 1860124784;
            _testClass = new GetAllAccountsRequest(_pageNumber, _pageSize);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAllAccountsRequest(_pageNumber, _pageSize);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void PageNumberIsInitializedCorrectly()
        {
            Assert.That(_testClass.PageNumber, Is.EqualTo(_pageNumber));
        }

        [Test]
        public void PageSizeIsInitializedCorrectly()
        {
            Assert.That(_testClass.PageSize, Is.EqualTo(_pageSize));
        }
    }
}