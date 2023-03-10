using Disco.Integration.Interfaces.Dtos.Stripe;
using Disco.Integration.Interfaces.Interfaces;
using Disco.Integration.Interfaces.Options;
using Microsoft.Extensions.Options;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Integration.Clients.HttpClients
{
    public class PaymentClient : IPaymentClient
    {
        private readonly CustomerService _customerService;
        private readonly ChargeService _chargeService;
        private readonly IOptions<StripeOptions> _options;

        public PaymentClient(
            CustomerService customerService, 
            ChargeService chargeService,
            IOptions<StripeOptions> options)
        {
            _customerService = customerService;
            _chargeService = chargeService;
            _options = options;
        }

        public Charge Charge(PaymentRequestDto paymentRequestDto)
        {
            var customer = _customerService.Create(new CustomerCreateOptions()
            {
                Email = paymentRequestDto.Email,
                Source = _options.Value.PublishKey,
            });

            var charge = _chargeService.Create(new ChargeCreateOptions()
            {
                Amount = paymentRequestDto.SaleAmount,
                Currency = "UAH",
                Description = paymentRequestDto.Description,
                ReceiptEmail = paymentRequestDto.Email,
                Customer = customer.Email,
            });

            return charge;
        }
    }
}
