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

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetUserById
{
    internal class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, UserDetailsResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IPostService _postService;
        private readonly IFollowerService _followerService;

        public GetUserByIdRequestHandler(IAccountService accountService, IAccountDetailsService accountDetailsService, IPostService postService, IFollowerService followerService)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _postService = postService;
            _followerService = followerService;
        }

        public async Task<UserDetailsResponseDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByIdAsync(request.Id);
            user.Account.Posts = await _postService.GetAllUserPosts(user);
            user.Account.Followers = await _followerService.GetFollowersAsync(user.Id);
            user.Account.Following = await _followerService.GetFollowingAsync(user.Id);

            var userDetailsResponseDto = await _accountDetailsService.GetUserDatailsAsync(user);

            return userDetailsResponseDto;
        }
    }
}
