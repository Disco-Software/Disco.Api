using AutoMapper;
using Disco.Business.Interfaces.Dtos.TicketMessage.CreateMessage;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.SendMessage
{
    public class SendMessageRequestHandler : IRequestHandler<SendMessageRequest, SendMessageResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly ITicketService _ticketService;
        private readonly ITicketMessageService _ticketMessageService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public SendMessageRequestHandler(
            IAccountService accountService,
            ITicketService ticketService,
            ITicketMessageService ticketMessageService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _ticketService = ticketService;
            _ticketMessageService = ticketMessageService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<SendMessageResponseDto> Handle(SendMessageRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var ticket = await _ticketService.GetAsync(request.TicketId);

            var ticketMessage = _mapper.Map<Domain.Models.Models.TicketMessage>(ticket);
            ticketMessage.TicketId = request.TicketId;
            ticketMessage.Account = user.Account;
            ticketMessage.Description = request.Message;
            ticketMessage.CreatedDate = DateTime.UtcNow;
            ticketMessage.AccountId = user.AccountId;
            ticketMessage.Ticket = ticket;

            ticket.TicketMessages.Add(ticketMessage);

            await _ticketMessageService.CreateAsync(ticketMessage);

            var sendTicketResponseDto = _mapper.Map<SendMessageResponseDto>(ticketMessage);
            sendTicketResponseDto.Account = _mapper.Map<AccountDto>(user.Account);
            sendTicketResponseDto.Message = request.Message;
            sendTicketResponseDto.Created = ticketMessage.CreatedDate;
            sendTicketResponseDto.Id = ticketMessage.Id;

            return sendTicketResponseDto;
        }
    }
}
