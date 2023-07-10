using Disco.Business.Interfaces.Dtos.AccountDetails;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetCurrentUser
{
    internal class GetCurrentUserRequestHandler : IRequestHandler<GetCurrentUserRequest, UserDetailsResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IPostService _postService;
        private readonly IFollowerService _followerService;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetCurrentUserRequestHandler(IAccountService accountService, IAccountDetailsService accountDetailsService, IPostService postService, IFollowerService followerService, IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _postService = postService;
            _followerService = followerService;
            _contextAccessor = contextAccessor;
        }

        public async Task<UserDetailsResponseDto> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            user.Account.Posts = await _postService.GetAllUserPosts(user);
            user.Account.Following = await _followerService.GetFollowingAsync(user.Id);
            user.Account.Followers = await _followerService.GetFollowersAsync(user.Id);

            var accountDetails = await _accountDetailsService.GetUserDatailsAsync(user);

            return accountDetails;
        }
    }
}
