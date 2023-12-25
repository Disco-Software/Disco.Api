using Disco.Business.Interfaces.Dtos.Account.User.RefreshToken;
using MediatR;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.RefreshToken
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
