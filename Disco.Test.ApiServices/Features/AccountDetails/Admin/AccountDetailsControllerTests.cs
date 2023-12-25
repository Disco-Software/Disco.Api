namespace Disco.Test.ApiServices.Features.AccountDetails.Admin
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountDetails.Admin;
    using Disco.Business.Interfaces.Dtos.Account;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class UserControllerTests
    {
        private AccountDetailsController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new AccountDetailsController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountDetailsController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreate()
        {
            // Arrange
            var dto = new RegistrationDto
            {
                UserName = "TestValue1802198873",
                Email = "TestValue2067740316",
                Password = "TestValue1206085796",
                ConfirmPassword = "TestValue1499855536"
            };

            // Act
            var result = await _testClass.Create(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange
            var id = 553397930;

            // Act
            await _testClass.Remove(id);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var pageNumber = 909963615;
            var pageSize = 1528795998;

            // Act
            var result = await _testClass.GetAllAsync(pageNumber, pageSize);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGetAccountsByPeriotAsync()
        {
            // Arrange
            var periot = 835016895;

            // Act
            var result = await _testClass.GetAccountsByPeriotAsync(periot);

            // Assert
            _mediator.Received(1);
        }
    }
}