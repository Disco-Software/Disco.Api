using AutoMapper;
using Disco.Business.Interfaces.Dtos.Group.User.GetAllGroupMessages;
using Disco.Domain.Interfaces;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.GetGroupMessages
{
    public class GetGroupMessagesRequestHandler : IRequestHandler<GetGroupMessagesRequest, IEnumerable<GetAllGroupMessagesResponseDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetGroupMessagesRequestHandler(
            IMessageRepository messageRepository,
            IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<GetAllGroupMessagesResponseDto>> Handle(GetGroupMessagesRequest request, CancellationToken cancellationToken)
        {
            var messages = _messageRepository.GetAllGroupMessages(request.GroupId, request.PageNumber, request.PageSize);

            var getGroupMessagesResponseDtos = _mapper.Map<IEnumerable<GetAllGroupMessagesResponseDto>>(messages);

            return Task.FromResult(getGroupMessagesResponseDtos);
        }
    }
}
