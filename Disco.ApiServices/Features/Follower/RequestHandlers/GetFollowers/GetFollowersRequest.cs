using Disco.Business.Interfaces.Dtos.Followers.User.GetFollowers;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowers
{
    public class GetFollowersRequest : IRequest<IEnumerable<GetFollowersResponseDto>>
    {
        public GetFollowersRequest(GetFollowersRequestDto dto)
        {
            Dto = dto;
        }

        public GetFollowersRequestDto Dto { get; }
    }
}
