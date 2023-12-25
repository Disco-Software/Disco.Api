using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAllAccounts;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts
{
    public class GetAllAccountsRequest : IRequest<IEnumerable<GetAllAccountsResponseDto>>
    {
        public GetAllAccountsRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
