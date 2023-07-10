using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.GetAll
{
    public class GetAllRequest : IRequest<IEnumerable<Domain.Models.Models.Group>>
    {
        public GetAllRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
