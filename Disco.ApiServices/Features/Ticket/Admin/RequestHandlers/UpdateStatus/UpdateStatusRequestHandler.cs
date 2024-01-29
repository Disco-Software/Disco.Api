using AutoMapper;
using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.UpdateTicketStatus;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.UpdateStatus
{
    public class UpdateStatusRequestHandler : IRequestHandler<UpdateStatusRequest, UpdateTicketStatusResponseDto>
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketStatusService _ticketStatusService;
        private readonly IMapper _mapper;

        public UpdateStatusRequestHandler(
            ITicketService ticketService,
            ITicketStatusService ticketStatusService,
            IMapper mapper)
        {
            _ticketService = ticketService;
            _ticketStatusService = ticketStatusService;
            _mapper = mapper;
        }

        public async Task<UpdateTicketStatusResponseDto> Handle(UpdateStatusRequest request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketService.GetTicketAsync(request.Id);

            var status = await _ticketStatusService.GetAsync(request.Status);
            if(status == null)
            {
                throw new ResourceNotFoundException(new Dictionary<string, string>
                {
                    { "status", "Status not found" }
                });
            }

            ticket.Status = status;

            await _ticketService.UpdateAsync(ticket);

            var updateTicketResponseDto = _mapper.Map<UpdateTicketStatusResponseDto>(ticket);
            updateTicketResponseDto.Owner.UserName = ticket.Owner.User.UserName;

            return updateTicketResponseDto;
        }
    }
}
