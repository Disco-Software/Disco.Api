using Disco.Integration.Interfaces.Dtos.Stripe;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Integration.Interfaces.Interfaces
{
    public interface IPaymentClient
    {
        Charge Charge(PaymentRequestDto paymentRequestDto);
    }
}
