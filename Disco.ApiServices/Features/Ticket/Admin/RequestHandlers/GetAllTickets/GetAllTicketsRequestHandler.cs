using AutoMapper;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.GetAllTickets
{
    public class GetAllTicketsRequestHandler : IRequestHandler<GetAllTicketsRequest, IEnumerable<GetAllTicketsResponseDto>>
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public GetAllTicketsRequestHandler(
            ITicketService ticketService,
            IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllTicketsResponseDto>> Handle(GetAllTicketsRequest request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketService.GetAllAsync(request.PageNumber, request.PageSize);

            var ticketDtos = _mapper.Map<IEnumerable<GetAllTicketsResponseDto>>(tickets);

            return ticketDtos;
        }
    }
}
