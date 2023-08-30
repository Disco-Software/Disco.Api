namespace Disco.Integration.Clients.Test.HttpClients
{
    using System;
    using Disco.Integration.Clients.HttpClients;
    using Disco.Integration.Interfaces.Dtos.Stripe;
    using Disco.Integration.Interfaces.Options;
    using Microsoft.Extensions.Options;
    using NSubstitute;
    using NUnit.Framework;
    using Stripe;

    [TestFixture]
    public class PaymentClientTests
    {
        private PaymentClient _testClass;
        private CustomerService _customerService;
        private ChargeService _chargeService;
        private IOptions<StripeOptions> _options;

        [SetUp]
        public void SetUp()
        {
            _customerService = new CustomerService();
            _chargeService = new ChargeService();
            _options = Substitute.For<IOptions<StripeOptions>>();
            _testClass = new PaymentClient(_customerService, _chargeService, _options);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new PaymentClient(_customerService, _chargeService, _options);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullCustomerService()
        {
            Assert.Throws<ArgumentNullException>(() => new PaymentClient(default(CustomerService), _chargeService, _options));
        }

        [Test]
        public void CannotConstructWithNullChargeService()
        {
            Assert.Throws<ArgumentNullException>(() => new PaymentClient(_customerService, default(ChargeService), _options));
        }

        [Test]
        public void CannotConstructWithNullOptions()
        {
            Assert.Throws<ArgumentNullException>(() => new PaymentClient(_customerService, _chargeService, default(IOptions<StripeOptions>)));
        }

        [Test]
        public void CanCallCharge()
        {
            // Arrange
            var paymentRequestDto = new PaymentRequestDto
            {
                Email = "TestValue2073245098",
                Description = "TestValue1023792209",
                SaleAmount = 1870104791L,
                Token = "TestValue909391239"
            };

            // Act
            var result = _testClass.Charge(paymentRequestDto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallChargeWithNullPaymentRequestDto()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Charge(default(PaymentRequestDto)));
        }

        [Test]
        public void ChargePerformsMapping()
        {
            // Arrange
            var paymentRequestDto = new PaymentRequestDto
            {
                Email = "TestValue410219147",
                Description = "TestValue954696413",
                SaleAmount = 1748673844L,
                Token = "TestValue47990197"
            };

            // Act
            var result = _testClass.Charge(paymentRequestDto);

            // Assert
            Assert.That(result.Description, Is.SameAs(paymentRequestDto.Description));
        }
    }
}