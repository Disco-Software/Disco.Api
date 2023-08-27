namespace Disco.Test.ApiServices.Features.Group
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Group;
    using Disco.Business.Interfaces.Dtos.Chat;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GroupControllerTests
    {
        private GroupController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new GroupController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GroupController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullMediator()
        {
            Assert.Throws<ArgumentNullException>(() => new GroupController(default(IMediator)));
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var dto = new CreateGroupRequestDto { UserId = 236435858 };

            // Act
            var result = await _testClass.CreateAsync(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateAsyncWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.CreateAsync(default(CreateGroupRequestDto)));
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var pageNumber = 271621291;
            var pageSize = 224256941;

            // Act
            var result = await _testClass.GetAllAsync(pageNumber, pageSize);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var groupId = 19942991;

            // Act
            await _testClass.DeleteAsync(groupId);

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}