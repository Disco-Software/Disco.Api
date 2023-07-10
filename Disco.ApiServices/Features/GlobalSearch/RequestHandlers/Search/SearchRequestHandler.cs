using Disco.Business.Interfaces.Dtos.Search;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.GlobalSearch.RequestHandlers.Search
{
    internal class SearchRequestHandler : IRequestHandler<SearchRequest, GlobalSearchResponseDto>
    {
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IPostService _postService;

        public SearchRequestHandler(
            IAccountDetailsService accountDetailsService,
            IPostService postService)
        {
            _accountDetailsService = accountDetailsService;
            _postService = postService;
        }

        public async Task<GlobalSearchResponseDto> Handle(SearchRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _accountDetailsService.GetAccountsByNameAsync(request.Search);
            var posts = await _postService.GetPostsByDescriptionAsync(request.Search);

            var searchResponseDto = new GlobalSearchResponseDto();
            searchResponseDto.Posts = posts;
            searchResponseDto.Accounts = accounts;

            return searchResponseDto;
        }
    }
}
