using MediatR;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsSearchResultsCount
{
    public class GetAccountsSearchResultsCountRequest : IRequest<int>
    {
        public GetAccountsSearchResultsCountRequest(
            string search)
        {
            Search = search;
        }

        public string Search {  get; }
    }
}
