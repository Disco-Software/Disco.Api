namespace Disco.Test.Domain.Models
{
    using System;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class RoleTests
    {
        private Role _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Role();
        }
    }
}