using AutoMapper;
using Disco.Business.Interfaces.Dtos.Post.User.GetCurrentUserPosts;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Post.RequestHandlers.GetUserPosts
{
    public class GetUserPostsRequestHandler : IRequestHandler<GetUserPostsRequest, IEnumerable<GetCurrentUserPostsResponseDto>>
    {
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetUserPostsRequestHandler(
            IAccountService accountService, 
            IPostService postService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _postService = postService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCurrentUserPostsResponseDto>> Handle(GetUserPostsRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var posts = await _postService.GetAllUserPosts(user, request.Dto);

            var getCurrentUserPostsResposneDtos = _mapper.Map<IEnumerable<GetCurrentUserPostsResponseDto>>(posts.AsEnumerable());

            return getCurrentUserPostsResposneDtos;
        }
    }
}
