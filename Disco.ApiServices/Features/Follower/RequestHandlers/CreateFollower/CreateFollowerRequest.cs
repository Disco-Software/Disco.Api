using Disco.Business.Interfaces.Dtos.Followers.User.CreateFollower;
using MediatR;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.CreateFollower
{
    public class CreateFollowerRequest : IRequest<CreateFollowerResponseDto>
    {
        public CreateFollowerRequest(CreateFollowerRequestDto dto)
        {
            Dto = dto;
        }

        public CreateFollowerRequestDto Dto { get; }
    }
}
