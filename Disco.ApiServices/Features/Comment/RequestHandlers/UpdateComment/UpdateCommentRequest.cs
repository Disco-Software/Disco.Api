using Disco.Business.Interfaces.Dtos.Comment.User.UpdateComment;
using MediatR;

namespace Disco.ApiServices.Features.Comment.RequestHandlers.UpdateComment
{
    public class UpdateCommentRequest : IRequest<UpdateCommentResponseDto>
    {
        public UpdateCommentRequest(UpdateCommentRequestDto dto)
        {
            Dto = dto;
        }

        public UpdateCommentRequestDto Dto { get; }
    }
}
