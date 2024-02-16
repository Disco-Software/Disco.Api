using AutoMapper;
using Disco.Business.Interfaces.Dtos.TicketMessage.CreateImageMessage;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.SendImageMessage
{
    public class SendImageMessageRequestHandler : IRequestHandler<SendImageMessageRequest, SendImageMessageResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly ITicketService _ticketService;
        private readonly ITicketMessageService _ticketMessageService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public SendImageMessageRequestHandler(
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

        public async Task<SendImageMessageResponseDto> Handle(SendImageMessageRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(request.User);
            var ticket = await _ticketService.GetAsync(request.TicketName);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < request.Images.Length; i++)
            {
               builder.Append(String.Join(",", request.Images[i]));
            }

            builder.Append($" {request.Message}");

            var ticketMessage = _mapper.Map<Domain.Models.Models.TicketMessage>(ticket);
            ticketMessage.TicketId = request.TicketId;
            ticketMessage.Account = user.Account;
            ticketMessage.Description = builder.ToString();
            ticketMessage.CreatedDate = DateTime.UtcNow;
            ticketMessage.AccountId = user.AccountId;
            ticketMessage.Ticket = ticket;

            ticket.TicketMessages.Add(ticketMessage);

            await _ticketMessageService.CreateAsync(ticketMessage);

            var sendTicketResponseDto = _mapper.Map<SendImageMessageResponseDto>(ticketMessage);
            sendTicketResponseDto.Account = _mapper.Map<AccountDto>(user.Account);
            sendTicketResponseDto.Message = builder.ToString();
            sendTicketResponseDto.Created = ticketMessage.CreatedDate;
            sendTicketResponseDto.Id = ticketMessage.Id;

            return sendTicketResponseDto;
        }
    }
}
