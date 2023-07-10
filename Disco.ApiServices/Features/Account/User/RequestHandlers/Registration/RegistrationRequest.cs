using Disco.Business.Interfaces.Dtos.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Registration
{
    public class RegistrationRequest : IRequest<UserResponseDto>
    {
        public RegistrationRequest(
            RegistrationDto registration)
        {
            Registration = registration;
        }

        public RegistrationDto Registration { get; }
    }
}
