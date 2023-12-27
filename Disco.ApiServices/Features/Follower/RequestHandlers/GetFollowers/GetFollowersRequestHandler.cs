using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.GetFollowers;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowers
{
    public class GetFollowersRequestHandler : IRequestHandler<GetFollowersRequest, IEnumerable<GetFollowersResponseDto>>
    {
        private readonly IFollowerService _followerService;
        private readonly IMapper _mapper;

        public GetFollowersRequestHandler(
            IFollowerService followerService,
            IMapper mapper)
        {
            _followerService = followerService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetFollowersResponseDto>> Handle(GetFollowersRequest request, CancellationToken cancellationToken)
        {
            var followers = await _followerService.GetFollowersAsync(request.Dto.UserId, request.Dto.PageNumber, request.Dto.PageSize);

            var followerDtos = _mapper.Map<IEnumerable<GetFollowersResponseDto>>(followers.AsEnumerable());

            return followerDtos;
        }
    }
}
