using Disco.Business.Interfaces.Dtos.Account.User.Facebook;
using Disco.Business.Interfaces.Dtos.Account.User.Google;
using MediatR;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Facebook
{
    public class FacebookRequest : IRequest<FacebookResponseDto>
    {
        public FacebookRequest(FacebookRequestDto dto)
        {
            Dto = dto;
        }

        public FacebookRequestDto Dto { get; }
    }
}
