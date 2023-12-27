using Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken;
using MediatR;

namespace Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken
{
    public class RefreshTokenRequest : IRequest<RefreshTokenResponseDto>
    {
        public RefreshTokenRequest(RefreshTokenRequestDto dto)
        {
            Dto = dto;
        }

        public RefreshTokenRequestDto Dto { get; }
    }
}
