using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccount;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccount
{
    public class GetAccountRequestHandler : IRequestHandler<GetAccountRequest, GetAccountResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IFollowerService _followerService;
        private readonly IPostService _postService;
        private readonly IStoryService _storyService;
        private readonly IMapper _mapper;

        public GetAccountRequestHandler(
            IAccountService accountService,
            IFollowerService followerService,
            IPostService postService,
            IStoryService storyService,
            IMapper mapper)
        {
            _accountService = accountService;
            _followerService = followerService;
            _postService = postService;
            _storyService = storyService;
            _mapper = mapper;
        }

        public async Task<GetAccountResponseDto> Handle(GetAccountRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByIdAsync(request.Id);

            var getAccountResponseDto = _mapper.Map<GetAccountResponseDto>(user.Account);

            getAccountResponseDto.Account.FollowersCount = _followerService.GetFollowersCount(user.AccountId);
            getAccountResponseDto.Account.FollowingsCount = _followerService.GetFollowingCount(user.AccountId);
            getAccountResponseDto.Account.PostsCount = _postService.GetPostsCount(user.AccountId);
            getAccountResponseDto.Account.StoriesCount = _storyService.GetStoriesCount(user.AccountId);

            return getAccountResponseDto;
        }
    }
}
