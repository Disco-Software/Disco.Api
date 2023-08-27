namespace Disco.Test.ApiServices.Features.GlobalSearch.RequestHandlers.Search
{
    using System;
    using Disco.ApiServices.Features.GlobalSearch.RequestHandlers.Search;
    using NUnit.Framework;

    [TestFixture]
    public class SearchRequestTests
    {
        private SearchRequest _testClass;
        private string _search;

        [SetUp]
        public void SetUp()
        {
            _search = "TestValue179468646";
            _testClass = new SearchRequest(_search);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new SearchRequest(_search);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidSearch(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new SearchRequest(value));
        }

        [Test]
        public void SearchIsInitializedCorrectly()
        {
            Assert.That(_testClass.Search, Is.EqualTo(_search));
        }
    }
}