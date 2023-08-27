namespace Disco.Test.ApiServices.Validators
{
    using System;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Business.Interfaces.Validators;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class LogInValidatorTests
    {
        private LogInValidator _testClass;
        private IAccountService _accountService;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _testClass = new LogInValidator(_accountService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new LogInValidator(_accountService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new LogInValidator(default(IAccountService)));
        }
    }
}