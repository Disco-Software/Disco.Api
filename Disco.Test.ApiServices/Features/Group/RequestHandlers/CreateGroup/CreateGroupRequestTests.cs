namespace Disco.Test.ApiServices.Features.Group.RequestHandlers.CreateGroup
{
    using System;
    using Disco.ApiServices.Features.Group.RequestHandlers.CreateGroup;
    using Disco.Business.Interfaces.Dtos.Chat;
    using NUnit.Framework;

    [TestFixture]
    public class CreateGroupRequestTests
    {
        private CreateGroupRequest _testClass;
        private CreateGroupRequestDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new CreateGroupRequestDto { UserId = 301848910 };
            _testClass = new CreateGroupRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateGroupRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateGroupRequest(default(CreateGroupRequestDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}