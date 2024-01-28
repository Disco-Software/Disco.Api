using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.DeleteAccountPhoto;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccountPhoto
{
    public class DeleteAccountPhotoRequestHandler : IRequestHandler<DeleteAccountPhotoRequest, DeleteAccountPhotoResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IFollowerService _followerService;
        private readonly IPostService _postService;
        private readonly IStoryService _storyService;
        private readonly IMapper _mapper;

        public DeleteAccountPhotoRequestHandler(
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

        public async Task<DeleteAccountPhotoResponseDto> Handle(DeleteAccountPhotoRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByIdAsync(request.Id);

            await _accountDetailsService.ClearUserPhotoAsync(user);

            var accountDto = _mapper.Map<AccountDto>(user.Account);

            var deleteAccountPhotoResponseDto = _mapper.Map<DeleteAccountPhotoResponseDto>(accountDto);

            deleteAccountPhotoResponseDto.Account.FollowersCount = _followerService.GetFollowersCount(request.Id);
            deleteAccountPhotoResponseDto.Account.FollowingCount = _followerService.GetFollowingsCount(request.Id);
            deleteAccountPhotoResponseDto.Account.PostsCount = _postService.GetPostsCount(request.Id);
            deleteAccountPhotoResponseDto.Account.StoriesCount = _storyService.GetStoriesCount(request.Id);

            return deleteAccountPhotoResponseDto;
        }
    }
}
