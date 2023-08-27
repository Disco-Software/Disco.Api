using Disco.Business.Interfaces.Dtos.Followers;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollower
{
    public class GetFollowerRequestHandler : IRequestHandler<GetFollowerRequest, FollowerResponseDto>
    {
        private readonly IFollowerService _followerService;

        public GetFollowerRequestHandler(IFollowerService followerService)
        {
            _followerService = followerService;
        }

        public async Task<FollowerResponseDto> Handle(GetFollowerRequest request, CancellationToken cancellationToken)
        {
            var follower = await _followerService.GetAsync(request.Id);

            return follower;
        }
    }
}
