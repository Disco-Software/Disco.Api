using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.GetFollowing;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowing
{
    public class GetFollowingRequestHandler : IRequestHandler<GetFollowingRequest, IEnumerable<GetFollowingResponseDto>>
    {
        private readonly IFollowerService _followerService;
        private readonly IMapper _mapper;

        public GetFollowingRequestHandler(
            IFollowerService followerService,
            IMapper mapper)
        {
            _followerService = followerService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetFollowingResponseDto>> Handle(GetFollowingRequest request, CancellationToken cancellationToken)
        {
            var following = await _followerService.GetFollowingAsync(request.Dto.UserId, request.Dto.PageNumber, request.Dto.PageSize);

            var followingDtos = _mapper.Map<IEnumerable<GetFollowingResponseDto>>(following.AsEnumerable());

            return followingDtos;
        }
    }
}
