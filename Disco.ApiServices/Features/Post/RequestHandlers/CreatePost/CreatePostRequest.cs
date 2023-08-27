using Disco.Business.Interfaces.Dtos.Posts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Post.RequestHandlers.CreatePost
{
    public class CreatePostRequest : IRequest<Domain.Models.Models.Post>
    {
        public CreatePostRequest(CreatePostDto dto)
        {
            Dto = dto;
        }

        public CreatePostDto Dto { get; }
    }
}
