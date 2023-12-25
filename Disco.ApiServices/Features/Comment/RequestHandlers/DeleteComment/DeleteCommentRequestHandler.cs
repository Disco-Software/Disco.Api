using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Comment.RequestHandlers.DeleteComment
{
    public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest>
    {
        private readonly ICommentService _commentService;
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteCommentRequestHandler(
            ICommentService commentService,
            IAccountService accountService,
            IPostService postService,
            IHttpContextAccessor contextAccessor)
        {
            _commentService = commentService;
            _accountService = accountService;
            _postService = postService;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var comment = await _commentService.GetCommentAsync(request.Dto.CommentId);
            var post = await _postService.GetPostAsync(request.Dto.PostId);

            if (post != null)
            {
                throw new Exception();
            }

            comment.Post = post;

            comment.Post.Comments.Remove(comment);

            await _commentService.RemoveCommentAsync(comment);
        }
    }
}
