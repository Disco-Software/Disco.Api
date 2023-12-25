using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Account.User.Register;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Registration
{
    public class RegistrationRequest : IRequest<RegisterResponseDto>
    {
        public RegistrationRequest(
            RegisterRequestDto dto)
        {
            Dto = dto;
        }

        public RegisterRequestDto Dto { get; }
    }
}
