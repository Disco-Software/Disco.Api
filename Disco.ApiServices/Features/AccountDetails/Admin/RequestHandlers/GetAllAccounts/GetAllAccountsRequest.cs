using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts
{
    public class GetAllAccountsRequest : IRequest<IEnumerable<Domain.Models.Models.Account>>
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
