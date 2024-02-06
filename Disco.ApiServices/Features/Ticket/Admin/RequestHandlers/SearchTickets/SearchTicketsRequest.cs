using Disco.Business.Interfaces.Dtos.Ticket.Admin.SearchTickets;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.SearchTickets
{
    public class SearchTicketsRequest : IRequest<IEnumerable<SearchTicketsResponseDto>>
    {
        public SearchTicketsRequest(
            string search, 
            int pageNumber, 
            int pageSize)
        {
            Search = search;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public string Search {  get; }
        public int PageNumber {  get; }
        public int PageSize { get; }
    }
}
