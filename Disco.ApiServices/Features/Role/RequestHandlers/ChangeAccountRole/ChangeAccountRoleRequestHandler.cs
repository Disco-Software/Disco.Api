using AutoMapper;
using Disco.Business.Interfaces.Dtos.Roles.Admin.ChangeAccountRole;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Role.RequestHandlers.ChangeAccountRole
{
    public class ChangeAccountRoleRequestHandler : IRequestHandler<ChangeAccountRoleRequest, ChangeAccountRoleResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IRoleService _roleService;
        private readonly IFollowerService _followerService;
        private readonly IPostService _postService;
        private readonly IStoryService _storyService;
        private readonly IMapper _mapper;

        public ChangeAccountRoleRequestHandler(
            IAccountService accountService,
            IAccountDetailsService accountDetailsService,
            IRoleService roleService,
            IFollowerService followerService,
            IPostService postService,
            IStoryService storyService,
            IMapper mapper) 
        { 
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _roleService = roleService;
            _followerService = followerService;
            _postService = postService;
            _storyService = storyService;
            _mapper = mapper;
        }

        public async Task<ChangeAccountRoleResponseDto> Handle(ChangeAccountRoleRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByIdAsync(request.ChangeAccountRoleRequestDto.Id);

            await _roleService.ChangeAccountRoleAsync(user, request.ChangeAccountRoleRequestDto.RoleName);

            user.RoleName = await _accountDetailsService.UpdateRoleAsync(user);

            var changeAccountRoleResponseDto = _mapper.Map<ChangeAccountRoleResponseDto>(user.Account);

            changeAccountRoleResponseDto.Account.FollowingCount = _followerService.GetFollowingsCount(user.AccountId);
            changeAccountRoleResponseDto.Account.FollowersCount = _followerService.GetFollowersCount(user.AccountId);
            changeAccountRoleResponseDto.Account.PostsCount = _postService.GetPostsCount(user.AccountId);
            changeAccountRoleResponseDto.Account.StoriesCount = _storyService.GetStoriesCount(user.AccountId);

            return changeAccountRoleResponseDto;
        }
    }
}
