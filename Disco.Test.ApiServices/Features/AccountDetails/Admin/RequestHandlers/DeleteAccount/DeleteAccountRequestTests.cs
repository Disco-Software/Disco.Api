namespace Disco.Test.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccount
{
    using System;
    using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccount;
    using NUnit.Framework;

    [TestFixture]
    public class DeleteAccountRequestTests
    {
        private DeleteAccountRequest _testClass;
        private int _id;

        [SetUp]
        public void SetUp()
        {
            _id = 755394904;
            _testClass = new DeleteAccountRequest(_id);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeleteAccountRequest(_id);

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