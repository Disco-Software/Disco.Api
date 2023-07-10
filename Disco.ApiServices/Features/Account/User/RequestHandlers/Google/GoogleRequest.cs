using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Google;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Google
{
    public class GoogleRequest : IRequest<UserResponseDto>
    {
        public GoogleRequest(GoogleLogInDto dto)
        {
            Dto = dto;
        }

        public GoogleLogInDto Dto { get; }
    }
}
