using Disco.Business.Interfaces.Dtos.Like.User.CreateLike;
using MediatR;

namespace Disco.ApiServices.Features.Like.RequestHandlers.CreateLike
{
    public class CreateLikeRequest : IRequest<CreateLikeResponseDto>
    {
        public CreateLikeRequest(int postId)
        {
            PostId = postId;
        }

        public int PostId { get; }
    }
}
