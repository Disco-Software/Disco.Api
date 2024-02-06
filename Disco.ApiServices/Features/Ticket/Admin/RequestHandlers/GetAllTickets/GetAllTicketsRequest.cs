using Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets;
using Disco.Business.Interfaces.Enums;
using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.GetAllTickets
{
    public class GetAllTicketsRequest : IRequest<IEnumerable<GetAllTicketsResponseDto>>
    {
        public GetAllTicketsRequest(
            int pageNumber, 
            int pageSize,
            string? status)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Status = status;
        }

        public int PageNumber {  get; }
        public int PageSize { get; }
        public string? Status { get; }
    }
}
