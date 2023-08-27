using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Post.RequestHandlers.DeletePost
{
    public class DeletePostRequestHandler : IRequestHandler<DeletePostRequest, string>
    {
        private readonly IPostService _postService;

        public DeletePostRequestHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<string> Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            await _postService.DeletePostAsync(request.PostId);

            return "Post was removed";
        }
    }
}
