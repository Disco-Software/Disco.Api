using AutoMapper;
using Disco.Business.Interfaces.Dtos.TicketMessage.GetAllMessages;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.GetAllMessages
{
    public class GetAllMessagesRequestHandler : IRequestHandler<GetAllMessagesRequest, IEnumerable<GetAllMessagesResponseDto>>
    {
        private readonly IAccountService _accountService;
        private readonly ITicketMessageService _ticketMessageService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetAllMessagesRequestHandler(
            IAccountService accountService,
            ITicketMessageService ticketMessageService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _ticketMessageService = ticketMessageService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllMessagesResponseDto>> Handle(GetAllMessagesRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var messages = await _ticketMessageService.GetAllAsync(request.GroupId, user.Id, request.PageNumber, request.PageSize);

            var messageDtos = _mapper.Map<IEnumerable<GetAllMessagesResponseDto>>(messages.AsEnumerable());

            return messageDtos;
        }
    }
}
