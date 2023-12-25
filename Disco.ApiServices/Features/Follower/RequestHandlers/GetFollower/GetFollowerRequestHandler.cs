using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.GetFollower;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollower
{
    public class GetFollowerRequestHandler : IRequestHandler<GetFollowerRequest, GetFollowerResponseDto>
    {
        private readonly IFollowerService _followerService;
        private readonly IMapper _mapper;

        public GetFollowerRequestHandler(
            IFollowerService followerService,
            IMapper mapper)
        {
            _followerService = followerService;
            _mapper = mapper;
        }

        public async Task<GetFollowerResponseDto> Handle(GetFollowerRequest request, CancellationToken cancellationToken)
        {
            var follower = await _followerService.GetAsync(request.Id);

            var currentUserDto = _mapper.Map<UserDto>(follower.FollowerAccount.User);
            var followingUserDto = _mapper.Map<UserDto>(follower.FollowingAccount.User);

            var currentAccountDto = _mapper.Map<AccountDto>(follower.FollowerAccount);
            var followingAccountDto = _mapper.Map<AccountDto>(follower.FollowingAccount);

            currentAccountDto.User = currentUserDto;
            followingAccountDto.User = followingUserDto;

            var getFollowerResponseDto = _mapper.Map<GetFollowerResponseDto>(currentAccountDto);
            getFollowerResponseDto.Following = followingAccountDto;
            getFollowerResponseDto.IsFollowing = follower.IsFollowing;

            return getFollowerResponseDto;
        }
    }
}
