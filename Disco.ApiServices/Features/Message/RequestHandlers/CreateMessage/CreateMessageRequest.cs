using Disco.Business.Interfaces.Dtos.Message.User.CreateMessage;
using MediatR;

namespace Disco.ApiServices.Features.Message.RequestHandlers.CreateMessage
{
    public class CreateMessageRequest : IRequest<CreateMessageResponseDto>
    {
        public CreateMessageRequest(
            CreateMessageRequestDto createMessageRequestDto)
        {
            CreateMessageRequestDto = createMessageRequestDto;
        }

        public CreateMessageRequestDto CreateMessageRequestDto { get; set; }
    }
}
