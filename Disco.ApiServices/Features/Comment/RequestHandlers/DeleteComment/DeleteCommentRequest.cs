using Disco.Business.Interfaces.Dtos.Comment.User.DeleteComment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Comment.RequestHandlers.DeleteComment
{
    public class DeleteCommentRequest : IRequest
    {
        public DeleteCommentRequest(
            DeleteCommentRequestDto dto)
        {
            Dto = dto;
        }

        public DeleteCommentRequestDto Dto { get; }
    }
}
