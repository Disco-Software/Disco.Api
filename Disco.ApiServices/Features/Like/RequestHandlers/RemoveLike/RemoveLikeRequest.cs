using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Like.RequestHandlers.RemoveLike
{
    public class RemoveLikeRequest : IRequest<int>
    {
        public RemoveLikeRequest(int postId)
        {
            PostId = postId;
        }

        public int PostId { get; }
    }
}
