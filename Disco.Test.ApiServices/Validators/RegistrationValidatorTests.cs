namespace Disco.Test.ApiServices.Validators
{
    using System;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Business.Interfaces.Validators;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class RegistrationValidatorTests
    {
        private RegistrationValidator _testClass;

        [SetUp]
        public void SetUp()
        {
            Assert.Null(_testClass);
        }
    }
}