using Disco.Business.Interfaces.Dtos.Posts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Post.RequestHandlers.GetUserPosts
{
    public class GetUserPostsRequest : IRequest<List<Disco.Domain.Models.Models.Post>>
    {
        public GetUserPostsRequest(GetAllPostsDto dto)
        {
            Dto = dto;
        }

        public GetAllPostsDto Dto { get; }
    }
}
