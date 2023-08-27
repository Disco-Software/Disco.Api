namespace Disco.Test.ApiServices.Features.AccountDetails.User.RequestHandlers.GetUserById
{
    using System;
    using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetUserById;
    using NUnit.Framework;

    [TestFixture]
    public class GetUserByIdRequestTests
    {
        private GetUserByIdRequest _testClass;
        private int _id;

        [SetUp]
        public void SetUp()
        {
            _id = 196443433;
            _testClass = new GetUserByIdRequest(_id);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetUserByIdRequest(_id);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void IdIsInitializedCorrectly()
        {
            Assert.That(_testClass.Id, Is.EqualTo(_id));
        }
    }
}