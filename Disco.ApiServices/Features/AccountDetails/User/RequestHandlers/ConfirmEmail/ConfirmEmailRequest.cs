using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ConfirmEmail
{
    public class ConfirmEmailRequest : IRequest
    {
        public ConfirmEmailRequest(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}
