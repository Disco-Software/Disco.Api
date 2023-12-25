using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Like.RequestHandlers.RemoveLike
{
    public class RemoveLikeRequestHandler : IRequestHandler<RemoveLikeRequest>
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

        public async Task Handle(RemoveLikeRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var post = await _postService.GetPostAsync(request.PostId);
            var like = await _likeService.GetAsync(user.AccountId, post.Id);

            await _likeService.DeleteLikeAsync(like);
        }
    }
}
