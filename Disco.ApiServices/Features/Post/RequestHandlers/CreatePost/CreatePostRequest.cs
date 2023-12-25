using Disco.Business.Interfaces.Dtos.Posts.User.CreatePost;
using MediatR;

namespace Disco.ApiServices.Features.Post.RequestHandlers.CreatePost
{
    public class CreatePostRequest : IRequest<CreatePostResponseDto>
    {
        public CreatePostRequest(CreatePostRequestDto dto)
        {
            Dto = dto;
        }

        public CreatePostRequestDto Dto { get; }
    }
}
