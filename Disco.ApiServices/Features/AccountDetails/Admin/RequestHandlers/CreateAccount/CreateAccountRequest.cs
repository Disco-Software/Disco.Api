using Disco.Business.Interfaces.Dtos.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.CreateAccount
{
    public class CreateAccountRequest : IRequest<UserResponseDto>
    {
        public CreateAccountRequest(RegistrationDto dto)
        {
            Dto = dto;
        }
        
        public RegistrationDto Dto { get; }
    }
}
