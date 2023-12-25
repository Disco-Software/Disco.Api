using AutoMapper;
using Disco.Business.Interfaces.Dtos.Like.User.CreateLike;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Like.RequestHandlers.CreateLike
{
    public class CreateLikeRequestHandler : IRequestHandler<CreateLikeRequest, CreateLikeResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly ILikeService _likeService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CreateLikeRequestHandler(
            IAccountService accountService, 
            IPostService postService, 
            ILikeService likeService, 
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _postService = postService;
            _likeService = likeService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<CreateLikeResponseDto> Handle(CreateLikeRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var post = await _postService.GetPostAsync(request.PostId);

            var like = _mapper.Map<Domain.Models.Models.Like>(user.Account);
            like.Post = post;
            like.PostId = request.PostId;

            await _likeService.CreateLikeAsync(like);

            var createLikeResponseDto = _mapper.Map<CreateLikeResponseDto>(like);

            return createLikeResponseDto;
        }
    }
}
