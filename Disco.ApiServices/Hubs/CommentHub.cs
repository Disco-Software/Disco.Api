using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Chat;
using Disco.Business.Interfaces.Dtos.Comments;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Hubs
{
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
     public class CommentHub : Hub
    {
        private readonly IAccountService _accountService;
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly IConnectionService _connectionService;
        private readonly IMapper _mapper;

        public CommentHub(
            IAccountService accountService,
            ICommentService commentService,
            IPostService postService,
            IConnectionService connectionService,
            IMapper mapper)
        {
            _accountService = accountService;
            _commentService = commentService;
            _postService = postService;
            _connectionService = connectionService;
            _mapper = mapper;
        }

        public override async Task OnConnectedAsync()
        {
            var user = await _accountService.GetAsync(Context.User);

            var connnection = new Connection()
            {
                IsConnected = true,
                Id = Context.ConnectionId
            };

            await _connectionService.CreateAsync(connnection, user.Account);

            await base.OnConnectedAsync();
        }

        public async Task SendCommentAsync(string message, int userId, int postId)
        {
            var user = await _accountService.GetAsync(Context.User);
            var post = await _postService.GetPostAsync(postId);

            var comment = _mapper.Map<Comment>(post);
            comment.Post = post;
            comment.PostId = post.Id;
            comment.CommentDescription = message;
            comment.Account = user.Account;
            comment.AccountId = user.AccountId;

            await _commentService.AddCommentAsync(comment);

            var commentDto = _mapper.Map<CommentDto>(comment);
            commentDto.Account = _mapper.Map<AccountDto>(comment.Account);
            commentDto.Account.User = _mapper.Map<UserDto>(comment.Account.User);

            await Clients.All.SendAsync("sendCommentAsync", user.Id, post.Id, commentDto);
        }

        public async Task RemoveCommentAsync(int commentId, int postId, int userId)
        {
            var post = await _postService.GetPostAsync(postId);
            var user = await _accountService.GetAsync(Context.User);

            var comment = await _commentService.GetCommentAsync(commentId);

            await _commentService.RemoveCommentAsync(comment);

            await Clients.All.SendAsync("RemoveCommentAsync", user, comment, post);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = await _accountService.GetAsync(Context.User);
            var connection = await _connectionService.GetAsync(Context.ConnectionId);

            await _connectionService.DeleteAsync(connection, user.Account); ;

            await base.OnDisconnectedAsync(exception);
        }
    }
}
