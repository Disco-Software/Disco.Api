using Disco.Business.Interfaces.Dtos.Posts;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Post.RequestHandlers.GetPosts
{
    public class GetPostsRequest : IRequest<List<Domain.Models.Models.Post>>
    {
        public GetPostsRequest(GetAllPostsDto dataTransferObject)
        {
            DataTransferObject = dataTransferObject;
        }

        public GetAllPostsDto DataTransferObject { get; }
    }
}
