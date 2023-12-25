using Disco.Business.Interfaces.Dtos.Comment.User.CreateComment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Comment.RequestHandlers.CreateComment
{
    public class CreateCommentRequest : IRequest<CreateCommentResponseDto>
    {
        public CreateCommentRequest(
            CreateCommentRequestDto dto)
        {
            Dto = dto;
        }

        public CreateCommentRequestDto Dto { get; set; }
    }
}
