using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Integration.Interfaces.Dtos.Stripe
{
    public class PaymentRequestDto
    {
        public string Email { get; set; }
        public string Description { get; set; }
        public long SaleAmount { get; set; }
        public string Token { get; set; }
    }
}
