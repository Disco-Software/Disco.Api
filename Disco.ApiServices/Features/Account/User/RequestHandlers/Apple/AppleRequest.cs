using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Account.User.Apple;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Apple
{
    public class AppleRequest : IRequest<AppleLogInResponseDto>
    {
        public AppleRequest(AppleLogInRequestDto dto)
        {
            Dto = dto;
        }

        public AppleLogInRequestDto Dto { get; }
    }
}
