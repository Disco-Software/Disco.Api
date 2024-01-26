using AutoMapper;
using Disco.Business.Interfaces.Dtos.Comment.User.CreateComment;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Comment.RequestHandlers.CreateComment
{
    public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, CreateCommentResponseDto>
    {
        private readonly ICommentService _commentService;
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CreateCommentRequestHandler(
            ICommentService commentService,
            IAccountService accountService,
            IPostService postService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _commentService = commentService;
            _accountService = accountService;
            _postService = postService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<CreateCommentResponseDto> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var post = await _postService.GetPostAsync(request.Dto.PostId);

            var comment = _mapper.Map<Domain.Models.Models.Comment>(request.Dto);
            comment.Post = post;
            comment.Account = user.Account;
            comment.PostId = post.Id;

            await _commentService.AddCommentAsync(comment);

            var userDto = _mapper.Map<UserDto>(user);
            var accountDto = _mapper.Map<AccountDto>(user.Account);
            var postDto = _mapper.Map<PostDto>(post);

            var createCommentResponseDto = _mapper.Map<CreateCommentResponseDto>(accountDto);
            createCommentResponseDto.Id = comment.PostId;
            createCommentResponseDto.Post = postDto;
            createCommentResponseDto.Description = comment.CommentDescription;

            return createCommentResponseDto;
        }
    }
}
