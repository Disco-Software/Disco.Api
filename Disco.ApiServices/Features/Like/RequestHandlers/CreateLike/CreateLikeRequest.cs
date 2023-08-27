using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Like.RequestHandlers.CreateLike
{
    public class CreateLikeRequest : IRequest<int>
    {
        public CreateLikeRequest(int postId)
        {
            PostId = postId;
        }

        public int PostId { get; }
    }
}
