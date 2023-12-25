using Disco.Business.Interfaces.Dtos.Message.User.UpdateMessage;
using MediatR;

namespace Disco.ApiServices.Features.Message.RequestHandlers.UpdateMessage
{
    public class UpdateMessageRequest : IRequest<UpdateMessageResponseDto>
    {
        public UpdateMessageRequest(
            UpdateMessageRequestDto updateMessageRequestDto)
        {
            UpdateMessageRequestDto = updateMessageRequestDto;
        }

        public UpdateMessageRequestDto UpdateMessageRequestDto { get; }
    }
}
