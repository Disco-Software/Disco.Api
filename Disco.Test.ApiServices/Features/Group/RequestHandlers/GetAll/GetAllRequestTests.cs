namespace Disco.Test.ApiServices.Features.Group.RequestHandlers.GetAll
{
    using System;
    using Disco.ApiServices.Features.Group.RequestHandlers.GetAll;
    using NUnit.Framework;

    [TestFixture]
    public class GetAllRequestTests
    {
        private GetAllGroupsRequest _testClass;
        private int _pageNumber;
        private int _pageSize;

        [SetUp]
        public void SetUp()
        {
            _pageNumber = 723983752;
            _pageSize = 388550892;
            _testClass = new GetAllGroupsRequest(_pageNumber, _pageSize);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAllGroupsRequest(_pageNumber, _pageSize);

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