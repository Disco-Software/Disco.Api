namespace Disco.Test.ApiServices.Features.Group.RequestHandlers.DeleteGroup
{
    using System;
    using Disco.ApiServices.Features.Group.RequestHandlers.DeleteGroup;
    using NUnit.Framework;

    [TestFixture]
    public class DeleteGroupRequestTests
    {
        private DeleteGroupRequest _testClass;
        private int _groupId;

        [SetUp]
        public void SetUp()
        {
            _groupId = 2077968639;
            _testClass = new DeleteGroupRequest(_groupId);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeleteGroupRequest(_groupId);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void GroupIdIsInitializedCorrectly()
        {
            Assert.That(_testClass.GroupId, Is.EqualTo(_groupId));
        }
    }
}