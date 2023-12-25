using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.GetUserById;
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
    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IPostService _postService;
        private readonly IFollowerService _followerService;
        private readonly IMapper _mapper;

        public GetUserByIdRequestHandler(
            IAccountService accountService, 
            IAccountDetailsService accountDetailsService, 
            IPostService postService, 
            IFollowerService followerService,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _postService = postService;
            _followerService = followerService;
            _mapper = mapper;
        }

        public async Task<GetUserByIdResponseDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByIdAsync(request.Id);
            user.Account.Posts = await _postService.GetAllUserPosts(user);
            user.Account.Followers = await _followerService.GetFollowersAsync(user.Id);
            user.Account.Following = await _followerService.GetFollowingAsync(user.Id);

            var accountDto = _mapper.Map<AccountDto>(user.Account);
            var userDto = _mapper.Map<UserDto>(user);

            userDto.Account = accountDto;

            var getUserByIdResponseDto = _mapper.Map<GetUserByIdResponseDto>(userDto);

            return getUserByIdResponseDto;
        }
    }
}
