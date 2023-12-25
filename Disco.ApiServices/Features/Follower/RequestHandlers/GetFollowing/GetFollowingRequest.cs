using Disco.Business.Interfaces.Dtos.Followers.User.GetFollowing;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowing
{
    public class GetFollowingRequest : IRequest<IEnumerable<GetFollowingResponseDto>>
    {
        public GetFollowingRequest(Business.Interfaces.Dtos.Followers.User.GetFollowing.GetFollowingRequestDto dto)
        {
            Dto = dto;
        }

        public Business.Interfaces.Dtos.Followers.User.GetFollowing.GetFollowingRequestDto Dto { get; }
    }
}
