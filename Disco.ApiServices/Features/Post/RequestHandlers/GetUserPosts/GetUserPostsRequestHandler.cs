using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Post.RequestHandlers.GetUserPosts
{
    public class GetUserPostsRequestHandler : IRequestHandler<GetUserPostsRequest, List<Domain.Models.Models.Post>>
    {
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetUserPostsRequestHandler(
            IAccountService accountService, 
            IPostService postService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _postService = postService;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<Domain.Models.Models.Post>> Handle(GetUserPostsRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            return await _postService.GetAllUserPosts(user, request.Dto);
        }
    }
}
