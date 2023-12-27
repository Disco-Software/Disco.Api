using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountEmail;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.ChangeAccountEmail
{
    public class ChangeAccountEmailRequestHandler : IRequestHandler<ChangeAccountEmailRequest, ChangeAccountEmailResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IFollowerService _followerService;
        private readonly IPostService _postService;
        private readonly IStoryService _storyService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public ChangeAccountEmailRequestHandler(
            IAccountService accountService,
            IAccountDetailsService accountDetailsService,
            IFollowerService followerService,
            IPostService postService,
            IStoryService storyService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _followerService = followerService;
            _postService = postService;
            _storyService = storyService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<ChangeAccountEmailResponseDto> Handle(ChangeAccountEmailRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByIdAsync(request.ChangeAccountEmailRequestDto.Id);

            await _accountDetailsService.ChangeEmailAsync(user, request.ChangeAccountEmailRequestDto.Email);

            var changeAccountEmailResponseDto = _mapper.Map<ChangeAccountEmailResponseDto>(user.Account);
            
            changeAccountEmailResponseDto.Account.FollowersCount = _followerService.GetFollowersCount(user.Account.Id);
            changeAccountEmailResponseDto.Account.FollowingsCount = _followerService.GetFollowingsCount(user.Account.Id);
            changeAccountEmailResponseDto.Account.PostsCount = _postService.GetPostCount(user.Account.Id);
            changeAccountEmailResponseDto.Account.StoriesCount = _storyService.GetStoryCount(user.AccountId);

            return changeAccountEmailResponseDto;
        }
    }
}
