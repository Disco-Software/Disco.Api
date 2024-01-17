using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.SearchAccountNames
{
    public class SearchAccountNamesRequest : IRequest<IEnumerable<string>>
    {
        public SearchAccountNamesRequest(
            string search)
        {
            Search = search;
        }

        public string Search {  get; }
    }
}
