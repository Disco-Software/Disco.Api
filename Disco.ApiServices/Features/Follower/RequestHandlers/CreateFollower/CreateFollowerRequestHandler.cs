using Disco.Business.Interfaces.Dtos.Followers;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.CreateFollower
{
    public class CreateFollowerRequestHandler : IRequestHandler<CreateFollowerRequest, FollowerResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IFollowerService _followerService;
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateFollowerRequestHandler(
            IAccountService accountService, 
            IFollowerService followerService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _followerService = followerService;
            _contextAccessor = contextAccessor;
        }

        public async Task<FollowerResponseDto> Handle(CreateFollowerRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var following = await _accountService.GetByIdAsync(request.Dto.FollowingAccountId);

            var followerDto = await _followerService.CreateAsync(user, following, request.Dto);

            return followerDto;
        }
    }
}
