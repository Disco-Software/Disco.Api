using Disco.Business.Interfaces.Dtos.Account.User.Google;
using MediatR;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Google
{
    public class GoogleRequest : IRequest<GoogleResponseDto>
    {
        public GoogleRequest(Business.Interfaces.Dtos.Account.User.Google.GoogleLogInRequestDto dto)
        {
            Dto = dto;
        }

        public Business.Interfaces.Dtos.Account.User.Google.GoogleLogInRequestDto Dto { get; }
    }
}
