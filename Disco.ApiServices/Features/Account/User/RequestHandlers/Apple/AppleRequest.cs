using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Apple;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Apple
{
    public class AppleRequest : IRequest<UserResponseDto>
    {
        public AppleRequest(AppleLogInDto dto)
        {
            Dto = dto;
        }

        public AppleLogInDto Dto { get; }
    }
}
