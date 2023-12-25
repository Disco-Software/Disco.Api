using AutoMapper;
using Disco.Business.Interfaces.Dtos.Post.User.GetPosts;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Post.RequestHandlers.GetPosts
{
    public class GetPostsRequestHandler : IRequestHandler<GetPostsRequest, IEnumerable<GetPostsResponseDto>>
    {
        private readonly IAccountService _accountService;
        private readonly IFollowerService _followerService;
        private readonly IPostService _postService;
        private readonly ILikeService _likeService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetPostsRequestHandler(
            IAccountService accountService,
            IFollowerService followerService,
            IPostService postService,
            ILikeService likeService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _followerService = followerService;
            _postService = postService;
            _likeService = likeService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetPostsResponseDto>> Handle(GetPostsRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            user.Account.Following = await _followerService.GetFollowingAsync(user.AccountId);
            user.Account.Followers = await _followerService.GetFollowersAsync(user.AccountId);

            var postList = await _postService.GetAllPostsAsync(user, request.DataTransferObject.PageNumber, request.DataTransferObject.PageSize);

            var getPosts = _mapper.Map<List<GetPostsResponseDto>>(postList);

            return getPosts;
        }
    }
}
