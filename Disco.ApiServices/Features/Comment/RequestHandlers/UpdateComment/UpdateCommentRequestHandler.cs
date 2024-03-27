using AutoMapper;
using Disco.Business.Interfaces.Dtos.Comment.User.UpdateComment;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Comment.RequestHandlers.UpdateComment
{
    public class UpdateCommentRequestHandler : IRequestHandler<UpdateCommentRequest, UpdateCommentResponseDto>
    {
        private readonly ICommentService _commentService;
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public UpdateCommentRequestHandler(
            ICommentService commentService,
            IAccountService accountService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _commentService = commentService;
            _accountService = accountService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<UpdateCommentResponseDto> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var comment = await _commentService.GetCommentAsync(request.Dto.CommentId);

            if (comment.Account != user.Account)
            {
                throw new InvalidOperationException();
            }

            comment.CommentDescription = request.Dto.Description;

            await _commentService.UpdateCommentAsync(comment);

            var userDto = _mapper.Map<UserDto>(user);
            var accountDto = _mapper.Map<AccountDto>(user.Account);
            var postDto = _mapper.Map<PostDto>(comment.Post);

            accountDto.User = userDto;

            var updateCommentResponseDto = _mapper.Map<UpdateCommentResponseDto>(accountDto);
            updateCommentResponseDto.Id = comment.PostId;
            updateCommentResponseDto.Post = postDto;
            updateCommentResponseDto.Description = request.Dto.Description;
            updateCommentResponseDto.CreatedDate = DateTime.UtcNow;

            return updateCommentResponseDto;
        }
    }
}
