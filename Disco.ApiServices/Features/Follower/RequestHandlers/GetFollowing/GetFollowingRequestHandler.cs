using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowing
{
    public class GetFollowingRequestHandler : IRequestHandler<GetFollowingRequest, List<UserFollower>>
    {
        private readonly IFollowerService _followerService;

        public GetFollowingRequestHandler(IFollowerService followerService)
        {
            _followerService = followerService;
        }

        public async Task<List<UserFollower>> Handle(GetFollowingRequest request, CancellationToken cancellationToken)
        {
            var following = await _followerService.GetFollowingAsync(request.Dto.UserId, request.Dto.PageNumber, request.Dto.PageSize);

            return following;
        }
    }
}
