using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowers
{
    public class GetFollowersRequestHandler : IRequestHandler<GetFollowersRequest, List<UserFollower>>
    {
        private readonly IFollowerService _followerService;

        public GetFollowersRequestHandler(IFollowerService followerService)
        {
            _followerService = followerService;
        }

        public async Task<List<UserFollower>> Handle(GetFollowersRequest request, CancellationToken cancellationToken)
        {
            var followers = await _followerService.GetFollowersAsync(request.Dto.UserId, request.Dto.PageNumber, request.Dto.PageSize);

            return followers;
        }
    }
}
