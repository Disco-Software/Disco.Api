using Disco.Business.Interfaces.Dtos.Post.User.GetPosts;
using Disco.Business.Interfaces.Dtos.Posts;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Post.RequestHandlers.GetPosts
{
    public class GetPostsRequest : IRequest<IEnumerable<GetPostsResponseDto>>
    {
        public GetPostsRequest(GetAllPostsDto dataTransferObject)
        {
            DataTransferObject = dataTransferObject;
        }

        public GetAllPostsDto DataTransferObject { get; }
    }
}
