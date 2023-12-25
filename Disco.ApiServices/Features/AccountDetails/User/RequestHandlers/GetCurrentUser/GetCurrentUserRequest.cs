using Disco.Business.Interfaces.Dtos.AccountDetails;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.GetCurrentUser;
using MediatR;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetCurrentUser
{
    public class GetCurrentUserRequest : IRequest<GetCurrentUserResponseDto> { }
}
