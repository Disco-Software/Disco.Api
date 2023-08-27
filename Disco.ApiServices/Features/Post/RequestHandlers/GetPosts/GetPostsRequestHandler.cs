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
    public class GetPostsRequestHandler : IRequestHandler<GetPostsRequest, List<Domain.Models.Models.Post>>
    {
        private readonly IAccountService _accountService;
        private readonly IFollowerService _followerService;
        private readonly IPostService _postService;
        private readonly ILikeService _likeService;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetPostsRequestHandler(
            IAccountService accountService,
            IFollowerService followerService,
            IPostService postService,
            ILikeService likeService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _followerService = followerService;
            _postService = postService;
            _likeService = likeService;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<Domain.Models.Models.Post>> Handle(GetPostsRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            user.Account.Following = await _followerService.GetFollowingAsync(user.AccountId);
            user.Account.Followers = await _followerService.GetFollowersAsync(user.AccountId);

            var postList = await _postService.GetAllPostsAsync(user, request.DataTransferObject.PageNumber, request.DataTransferObject.PageSize) as List<Domain.Models.Models.Post>;

            for (int i = 0; i < postList.Count; i++)
            {
                var post = postList[i];
                post.Likes = await _likeService.GetAllLikesAsync(post.Id);
            }

            return postList;
        }
    }
}
