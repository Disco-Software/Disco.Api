using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ChangeSelectedUserPassword;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ChangeSelectedUserPassword
{
    public class ChangeSelectedUserPasswordRequestHandler : IRequestHandler<ChangeSelectedUserPasswordRequest, ChangeSelectedUserPasswordResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly IFollowerService _followerService;
        private readonly IPostService _postService;
        private readonly IStoryService _storyService;
        private readonly IMapper _mapper;

        public ChangeSelectedUserPasswordRequestHandler(
            IAccountService accountService,
            IAccountPasswordService accountPasswordService,
            IFollowerService followerService,
            IPostService postService,
            IStoryService storyService,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _followerService = followerService;
            _postService = postService;
            _storyService = storyService;
            _mapper = mapper;
        }

        public async Task<ChangeSelectedUserPasswordResponseDto> Handle(ChangeSelectedUserPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByIdAsync(request.ChangeSelectedUserPasswordRequestDto.Id);

            await _accountPasswordService.ChangeSelectedUserPasswordAsynnc(user, request.ChangeSelectedUserPasswordRequestDto.Password);

            var changeSelectedUserPasswordResponseDto = _mapper.Map<ChangeSelectedUserPasswordResponseDto>(user.Account);
            
            changeSelectedUserPasswordResponseDto.Account.FollowersCount = _followerService.GetFollowersCount(request.ChangeSelectedUserPasswordRequestDto.Id);
            changeSelectedUserPasswordResponseDto.Account.FollowingsCount = _followerService.GetFollowersCount(request.ChangeSelectedUserPasswordRequestDto.Id);
            changeSelectedUserPasswordResponseDto.Account.PostsCount = _followerService.GetFollowersCount(request.ChangeSelectedUserPasswordRequestDto.Id);
            changeSelectedUserPasswordResponseDto.Account.StoriesCount = _followerService.GetFollowersCount(request.ChangeSelectedUserPasswordRequestDto.Id);

            return changeSelectedUserPasswordResponseDto;
        }
    }
}
