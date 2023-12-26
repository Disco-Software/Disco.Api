using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.SearchAccountEmails
{
    public class SearchAccountEmailsRequest : IRequest<IEnumerable<string>>
    {
        public SearchAccountEmailsRequest(
            string search)
        {
            Search = search;
        }

        public string Search { get; }
    }
}
