using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.SearchAccounts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.SearchAccounts
{
    public class SearchAccountsRequest : IRequest<IEnumerable<SearchAccountsResponseDto>>
    {
        public SearchAccountsRequest(
            string search,
            int pageNumber,
            int pageSize)
        {
            Search = search;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public string Search { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
