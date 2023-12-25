using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.GetRecomended;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetRecomended
{
    public class GetRecomendedRequestHandler : IRequestHandler<GetRecomendedRequest, IEnumerable<GetRecomendedResponseDto>>
    {
        private readonly IAccountService _accountService;
        private readonly IFollowerService _followerService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetRecomendedRequestHandler(
            IFollowerService followerService, 
            IAccountService accountService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _followerService = followerService;
            _accountService = accountService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetRecomendedResponseDto>> Handle(GetRecomendedRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var recomended = new List<Domain.Models.Models.Account>();

            foreach (var followings in user.Account.Following)
            {
                followings.FollowingAccount = await _accountService.GetByAccountIdAsync(followings.FollowingAccountId);

                foreach (var following in followings.FollowingAccount.Following)
                {
                    if (following.FollowingAccount.Following.Count == 0)
                    {
                        continue;
                    }

                    recomended.Add(following.FollowingAccount);
                }
            }

            var getRecomendedAccounts = _mapper.Map<IEnumerable<GetRecomendedResponseDto>>(recomended.AsEnumerable());

            return getRecomendedAccounts;
        }
    }
}
