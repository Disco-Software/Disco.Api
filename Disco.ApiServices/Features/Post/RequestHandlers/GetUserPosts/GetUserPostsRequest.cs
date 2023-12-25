using Disco.Business.Interfaces.Dtos.Post.User.GetCurrentUserPosts;
using Disco.Business.Interfaces.Dtos.Posts;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Post.RequestHandlers.GetUserPosts
{
    public class GetUserPostsRequest : IRequest<IEnumerable<GetCurrentUserPostsResponseDto>>
    {
        public GetUserPostsRequest(GetAllPostsDto dto)
        {
            Dto = dto;
        }

        public GetAllPostsDto Dto { get; }
    }
}
