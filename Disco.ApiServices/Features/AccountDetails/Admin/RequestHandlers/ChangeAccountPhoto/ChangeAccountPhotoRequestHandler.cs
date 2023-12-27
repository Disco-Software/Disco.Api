using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountPhoto;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.ChangeAccountPhoto
{
    public class ChangeAccountPhotoRequestHandler : IRequestHandler<ChangeAccountPhotoRequest, ChangeAccountPhotoResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IFollowerService _followerService;
        private readonly IPostService _postService;
        private readonly IStoryService _storyService;
        private readonly IMapper _mapper;

        public ChangeAccountPhotoRequestHandler(
            IAccountService accountService,
            IAccountDetailsService accountDetailsService,
            IFollowerService followerService,
            IPostService postService,
            IStoryService storyService,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _followerService = followerService;
            _postService = postService;
            _storyService = storyService;
            _mapper = mapper;
        }

        public async Task<ChangeAccountPhotoResponseDto> Handle(ChangeAccountPhotoRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByIdAsync(request.Userid);

            await _accountDetailsService.ChengePhotoAsync(user, request.Photo);

            var changeAccountPhotoResponseDto = _mapper.Map<ChangeAccountPhotoResponseDto>(user.Account);

            changeAccountPhotoResponseDto.Account.FollowersCount = _followerService.GetFollowersCount(request.Userid);
            changeAccountPhotoResponseDto.Account.FollowingCount = _followerService.GetFollowingsCount(request.Userid);
            changeAccountPhotoResponseDto.Account.PostsCount = _postService.GetPostsCount(request.Userid);
            changeAccountPhotoResponseDto.Account.StoriesCount = _storyService.GetStoriesCount(request.Userid);

            return changeAccountPhotoResponseDto;
        }
    }
}
