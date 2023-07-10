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
    internal class GetRecomendedRequestHandler : IRequestHandler<GetRecomendedRequest, List<Domain.Models.Models.Account>>
    {
        private readonly IAccountService _accountService;
        private readonly IFollowerService _followerService;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetRecomendedRequestHandler(
            IFollowerService followerService, 
            IAccountService accountService,
            IHttpContextAccessor contextAccessor)
        {
            _followerService = followerService;
            _accountService = accountService;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<Domain.Models.Models.Account>> Handle(GetRecomendedRequest request, CancellationToken cancellationToken)
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

            return recomended;
        }
    }
}
