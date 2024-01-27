using Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets;
using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.GetAllTickets
{
    public class GetAllTicketsRequest : IRequest<IEnumerable<GetAllTicketsResponseDto>>
    {
        public GetAllTicketsRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber {  get; }
        public int PageSize { get; }
    }
}
