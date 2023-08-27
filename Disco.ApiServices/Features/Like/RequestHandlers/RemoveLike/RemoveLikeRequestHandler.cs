using Disco.Business.Exceptions;
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

namespace Disco.ApiServices.Features.Like.RequestHandlers.RemoveLike
{
    public class RemoveLikeRequestHandler : IRequestHandler<RemoveLikeRequest, int>
    {
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly ILikeService _likeService;
        private readonly IHttpContextAccessor _contextAccessor;

        public RemoveLikeRequestHandler(
            IAccountService accountService,
            IPostService postService, 
            ILikeService likeService, 
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _postService = postService;
            _likeService = likeService;
            _contextAccessor = contextAccessor;
        }

        public async Task<int> Handle(RemoveLikeRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var post = await _postService.GetPostAsync(request.PostId);

            if (user == null)
            {
                throw new ResourceNotFoundException(new Dictionary<string, string>
                {
                    {"user", "User claim not valid" }
                });
            }

            var likes = await _likeService.RemoveLikeAsync(user, post);

            return likes.Count;
        }
    }
}
