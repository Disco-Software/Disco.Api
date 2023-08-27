using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Post.RequestHandlers.DeletePost
{
    public class DeletePostRequest : IRequest<string>
    {
        public DeletePostRequest(int postId)
        {
            PostId = postId;
        }

        public int PostId { get; }
    }
}
