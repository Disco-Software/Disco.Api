using Disco.Business.Interfaces.Dtos.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken
{
    public class RefreshTokenRequest : IRequest<UserResponseDto>
    {
        public RefreshTokenRequest(RefreshTokenDto dto)
        {
            Dto = dto;
        }

        public RefreshTokenDto Dto { get; }
    }
}
