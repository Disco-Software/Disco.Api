using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.CreateFollower;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.CreateFollower
{
    public class CreateFollowerRequestHandler : IRequestHandler<CreateFollowerRequest, CreateFollowerResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IFollowerService _followerService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CreateFollowerRequestHandler(
            IAccountService accountService, 
            IFollowerService followerService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _followerService = followerService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<CreateFollowerResponseDto> Handle(CreateFollowerRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var following = await _accountService.GetByIdAsync(request.Dto.AccountId);

            var userFollower = _mapper.Map<UserFollower>(user);
            userFollower.FollowingAccountId = following.AccountId;
            userFollower.FollowingAccount = following.Account;
            userFollower.IsFollowing = true;

            await _followerService.CreateAsync(userFollower);

            var currentUserDto = _mapper.Map<UserDto>(user);
            var userDto = _mapper.Map<UserDto>(following);

            var currentAccountDto = _mapper.Map<AccountDto>(user.Account);
            var accountDto = _mapper.Map<AccountDto>(following.Account);

            var createFollowingResponseDto = _mapper.Map<CreateFollowerResponseDto>(currentAccountDto);
            createFollowingResponseDto.Follower = currentAccountDto;
            createFollowingResponseDto.IsFollowing = true;
            createFollowingResponseDto.Following = accountDto;

            return createFollowingResponseDto;
        }
    }
}
