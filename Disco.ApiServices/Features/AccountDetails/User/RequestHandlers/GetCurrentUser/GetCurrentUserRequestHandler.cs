using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.GetCurrentUser;
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
    public class GetCurrentUserRequestHandler : IRequestHandler<GetCurrentUserRequest, GetCurrentUserResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IPostService _postService;
        private readonly IFollowerService _followerService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetCurrentUserRequestHandler(
            IAccountService accountService, 
            IAccountDetailsService accountDetailsService, 
            IPostService postService, 
            IFollowerService followerService, 
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _postService = postService;
            _followerService = followerService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<GetCurrentUserResponseDto> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            user.Account.Posts = await _postService.GetAllUserPosts(user);
            user.Account.Following = await _followerService.GetFollowingAsync(user.Id);
            user.Account.Followers = await _followerService.GetFollowersAsync(user.Id);

            var userDetailss = await _accountDetailsService.GetUserDatailsAsync(user);

            var accountDto = _mapper.Map<AccountDto>(userDetailss.Account);
            var userDto = _mapper.Map<UserDto>(userDetailss);

            userDto.Account = accountDto;

            var getCurrentUserResponseDto = _mapper.Map<GetCurrentUserResponseDto>(userDto);

            return getCurrentUserResponseDto;
        }
    }
}
