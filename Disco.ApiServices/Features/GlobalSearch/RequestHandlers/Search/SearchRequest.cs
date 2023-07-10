using Disco.Business.Interfaces.Dtos.Search;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.GlobalSearch.RequestHandlers.Search
{
    public class SearchRequest : IRequest<GlobalSearchResponseDto>
    {
        public SearchRequest(string search)
        {
            Search = search;
        }

        public string Search { get; }
    }
}
