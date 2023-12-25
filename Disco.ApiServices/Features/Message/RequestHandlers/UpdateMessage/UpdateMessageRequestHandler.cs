using AutoMapper;
using Disco.Business.Interfaces.Dtos.Message.User.UpdateMessage;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Message.RequestHandlers.UpdateMessage
{
    public class UpdateMessageRequestHandler : IRequestHandler<UpdateMessageRequest, UpdateMessageResponseDto>
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public UpdateMessageRequestHandler(
            IMessageService messageService,
            IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task<UpdateMessageResponseDto> Handle(UpdateMessageRequest request, CancellationToken cancellationToken)
        {
            var message = await _messageService.GetByIdAsync(request.UpdateMessageRequestDto.MessageId);

            message.Description = request.UpdateMessageRequestDto.Description;

            await _messageService.UpdateAsync(message);

            var updateMessageResponseDto = _mapper.Map<UpdateMessageResponseDto>(message);

            return updateMessageResponseDto;
        }
    }
}
