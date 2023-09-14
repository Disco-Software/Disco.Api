namespace Disco.Test.ApiServices.Features.AccountDetails.User
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountDetails.User;
    using Disco.Business.Interfaces.Dtos.AccountDetails;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class AccountDetailsControllerTests
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
        public async Task CanCallChangePhotoAsync()
        {
            // Arrange
            var dto = new UpdateAccountDto { Photo = Substitute.For<IFormFile>() };

            // Act
            var result = await _testClass.ChangePhotoAsync(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGetCurrentUserAsync()
        {
            // Act
            var result = await _testClass.GetCurrentUserAsync();

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGetUserByIdAsync()
        {
            // Arrange
            var id = 1637481518;

            // Act
            var result = await _testClass.GetUserByIdAsync(id);

            // Assert
            _mediator.Received(1);
        }
    }
}