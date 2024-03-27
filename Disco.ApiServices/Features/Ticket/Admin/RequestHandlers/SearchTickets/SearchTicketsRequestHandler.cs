using AutoMapper;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.SearchTickets;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.SearchTickets
{
    public class SearchTicketsRequestHandler : IRequestHandler<SearchTicketsRequest, IEnumerable<SearchTicketsResponseDto>>
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public SearchTicketsRequestHandler(
            ITicketService ticketService,
            IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchTicketsResponseDto>> Handle(SearchTicketsRequest request, CancellationToken cancellationToken)
        {
            var searchResult = await _ticketService.SearchAsync(request.Search, request.PageNumber, request.PageSize);

            var ticketDtos = _mapper.Map<IEnumerable<SearchTicketsResponseDto>>(searchResult.AsEnumerable());

            return ticketDtos;
        }
    }
}
