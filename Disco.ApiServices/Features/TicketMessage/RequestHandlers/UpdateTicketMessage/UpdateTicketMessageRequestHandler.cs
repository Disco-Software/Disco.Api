using AutoMapper;
using Disco.Business.Interfaces.Dtos.TicketMessage.UpdateMessage;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.UpdateTicketMessage
{
    public class UpdateTicketMessageRequestHandler : IRequestHandler<UpdateTicketMessageRequest, UpdateTicketMessageResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly ITicketMessageService _ticketMessageService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public UpdateTicketMessageRequestHandler(
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

        public async Task<UpdateTicketMessageResponseDto> Handle(UpdateTicketMessageRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var message = await _ticketMessageService.GetAsync(request.Id);

            if (message.AccountId != user.AccountId)
            {
                throw new System.Exception("You are not the owner of this message");
            }

            message.Description = request.Message;

            await _ticketMessageService.UpdateAsync(message);

            var updatedTicketMessageResponseDto = _mapper.Map<UpdateTicketMessageResponseDto>(message);

            return updatedTicketMessageResponseDto;
        }
    }
}
