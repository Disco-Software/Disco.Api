using AutoMapper;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets;
using Disco.Business.Interfaces.Enums;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.GetAllTickets
{
    public class GetAllTicketsRequestHandler : IRequestHandler<GetAllTicketsRequest, IEnumerable<GetAllTicketsResponseDto>>
    {
        private readonly ITicketSummaryService _ticketService;
        private readonly IMapper _mapper;

        public GetAllTicketsRequestHandler(
            ITicketSummaryService ticketService,
            IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllTicketsResponseDto>> Handle(GetAllTicketsRequest request, CancellationToken cancellationToken)
        {
            if (request.Status == TicketStatusType.Archived.ToString())
            {
                var statusType = Enum.Parse<TicketStatusType>(request.Status);

                var archivedTickets = await _ticketService.GetAllAsync(request.PageNumber, request.PageSize, TicketStatusType.Archived);

                var archivedTicketDtos = _mapper.Map<IEnumerable<GetAllTicketsResponseDto>>(archivedTickets.AsEnumerable());

                return archivedTicketDtos;
            }

            var tickets = await _ticketService.GetAllAsync(request.PageNumber, request.PageSize, TicketStatusType.Active);

            var ticketDtos = _mapper.Map<IEnumerable<GetAllTicketsResponseDto>>(tickets.AsEnumerable());

            return ticketDtos;
        }
    }
}
