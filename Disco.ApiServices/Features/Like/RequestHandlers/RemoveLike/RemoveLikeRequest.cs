using MediatR;

namespace Disco.ApiServices.Features.Like.RequestHandlers.RemoveLike
{
    public class RemoveLikeRequest : IRequest
    {
        public RemoveLikeRequest(int postId)
        {
            PostId = postId;
        }

        public int PostId { get; }
    }
}
